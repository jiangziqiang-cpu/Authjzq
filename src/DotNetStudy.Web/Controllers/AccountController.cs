using AuthorityManagement.Web.Services;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using DotNetStudy.Web.ViewModels.AccountViewModels;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Poseidon.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Controllers
{

    public class AccountController : WebControllerBase
    {
        private readonly UserService _userService;
       
        private readonly UserRoleSever _userRoleSever;
        private readonly RoleSever _roleSever;
        private readonly RoleClaimsSever _roleClaimsSever;


     
        private IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(UserService userService,
            IServiceProvider serviceProvider, IWebHostEnvironment environment,
            UserRoleSever userRoleSever, RoleSever roleSever, IHttpContextAccessor httpContextAccessor, RoleClaimsSever roleClaimsSever)
            : base(serviceProvider, httpContextAccessor)
        {
            _userService = userService;
            _environment = environment;
                    
            _userRoleSever = userRoleSever;
            _roleSever = roleSever;
            _httpContextAccessor = httpContextAccessor;
            _roleClaimsSever = roleClaimsSever;
        }
        public IActionResult Register()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterModel model/*,PurseModel purseModel*/)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //var user = Mapper.Map<User>(model);
        //        //await _userService.CreateAsync(user);
        //        //var purse = Mapper.Map<Purse>(purseModel);
        //        //purseModel.UserId = user.Id;
        //        //purse.UserId = user.Id;
        //        //await _purseService.CreateAsync(purse);
        //    }
        //    return Redirect("/Account/Login");
        //}
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userService.FindByNameAsync(model.UserName);
                string password=Tools.GetMD5(model.Password);
                //判断完用户名之后，判断密码是否相等
                if (user != null && user.Password == password)
                {                  
                    await AddClaimAndSignIn(user);
                    //await _httpContextAccessor.HttpContext.SignOutAsync();
                    var roles = await _roleSever.GetRoleByUserId(user.Id);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码错误");

                }
            }
            return View(model);

        }


        /// <summary>
        /// 在登陆的时候把角色权限的令牌添加进去
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddClaimAndSignIn(User user)
        {
           var roles=  await _roleSever.GetRoleByUserId(user.Id);
            List<int> roleIds = new List<int>();
            foreach (var item in roles)
            {
                roleIds.Add(item.Id);
            }
            var roleClaims= _roleClaimsSever.GetRoleClaims(roleIds);

              //var claims = new[]
              //      {
              //          new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
              //          new Claim(ClaimTypes.Name,user.UserName)
              //      };
            var claimIdentity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            foreach (var item in roleClaims)
            {
                claimIdentity.AddClaim(new Claim("RoleClaims", item.ClaimValue));
            }
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await _httpContextAccessor.HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, claimPrincipal, new AuthenticationProperties
            {
                IsPersistent = true
            });

        }


        /// <summary>
        /// 查看当前用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> UserProfile()
        {          
            var user = await _userService.GetByIdAsync(UserIdForClims.Value);
            var profile = Mapper.Map<ProfileModel>(user);
            return View(profile);
        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UserProfile(ProfileModel model)
        {
            if (ModelState.IsValid)
            {              
                var user = await _userService.GetByIdAsync(UserIdForClims.Value);
                if (user == null)
                {
                    return NotFound();
                }
                model.Avator = user.Avator;
                user = Mapper.Map(model, user);
                await _userService.UpdateProfileAsync(user);
                return RedirectToAction(nameof(UserProfile));
            }
            return View(model);
        }

        /// <summary>
        ///如果没授权返回没授权的页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> UpdatePassword()
        {         
            var user = await _userService.GetByIdAsync(UserIdForClims.Value);
            var profile = Mapper.Map<UpdatePasswordModel>(user);
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordModel model)
        {
            if (ModelState.IsValid)
            {               
                var user = await _userService.GetByIdAsync(UserIdForClims.Value);
                if (user == null)
                {
                    return NotFound();
                }
                model.UserName = user.UserName;
                user = Mapper.Map(model, user);
                user.Password = model.NewPassword;
                await _userService.UpdatePasswordAsync(user);
            }
            return View(nameof(Login));
        }

        public async Task<IActionResult>  SignOut()
        {          
            await _httpContextAccessor.HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Redirect(nameof(Login));
        }

        public async Task<IActionResult> UploadAvator()
        {         
            var user = await _userService.GetByIdAsync(UserIdForClims.Value);
            var avator = Mapper.Map<UploadAvatorModel>(user);
            return View(avator);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImg(int Id)
        {
            string path = "";
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    // 上传目录处理
                    var fileProvider = _environment.WebRootFileProvider;
                    var fileInfo = fileProvider.GetFileInfo("images");
                    if (!fileInfo.Exists)
                    {
                        Directory.CreateDirectory(fileInfo.PhysicalPath);
                    }
                    // 文件类型过滤
                    var filters = new[] { "image/png", "image/jpeg", "image/gif" };
                    if (!filters.Contains(file.ContentType))
                    {
                        //ModelState.AddModelError("", "上传图片格式不正确。");
                        //return View(model);

                        return RedirectToAction("/User/ShowAllUser");
                    }
                    // 文件名处理
                    var extensionsName = file.FileName.Substring(file.FileName.LastIndexOf("."));
                    var newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + extensionsName;
                    var filePath = fileInfo.PhysicalPath + "\\" + newFileName;
                    // 写入文件
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    //更新用户图片数据        
                    path = newFileName;
                }
                var users = await _userService.GetByIdAsync(Id);
                users.Avator = "/images/" + path;
                await _userService.UpdateProfileAsync(users);
            }
            return RedirectToAction("/User/ShowAllUser");
        }
       

        private User UploadProfile(User user)
        {
            /*             
             图片路径可优化成绝对网络路径
             */
            if (Request.Form.Files != null && Request.Form.Files.Count > 0 && Request.Form.Files[0].Length > 0)
            {
                try
                {
                    var webRootPath = _environment.WebRootPath;
                    var imageDirPath = $"{webRootPath}/users";
                    if (!Directory.Exists(imageDirPath))
                        Directory.CreateDirectory(imageDirPath);

                    var fileName = $"{DateTime.Now:yyyyMMddHHmmssff}{ new Random().Next(10000, 99999) }.png";
                    //存储路径
                    var filePath = $"{imageDirPath}/{fileName}";

                    //上传文件
                    using (Stream stream = Request.Form.Files[0].OpenReadStream())
                    {
                        ImageHelper.Square(stream, filePath, 160, 160);
                    }
                    if (user.Avator != null)
                    {
                        var oldHeadImagePath = $"{webRootPath}{user.Avator}";
                        if (Directory.Exists(oldHeadImagePath))
                            Directory.Delete(oldHeadImagePath);
                    }
                    //删除旧的图片
                    user.Avator = $"/users/{fileName}";//图片文件相对路径
                }
                catch
                {

                }
            }
            return user;
        }
     

    }
}

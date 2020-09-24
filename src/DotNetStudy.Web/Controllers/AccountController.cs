using AutoMapper;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using DotNetStudy.Web.ViewModels.AccountViewModels;
using DotNetStudy.Web.ViewModels.PurseViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Controllers
{
    public class AccountController : WebControllerBase
    {
        private readonly UserService _userService;
        private readonly PurseService _purseService;

        private readonly FileSever _fileSever;
        private IWebHostEnvironment _environment;
        public AccountController(UserService userService,
            IServiceProvider serviceProvider, IWebHostEnvironment environment, PurseService purseService, FileSever fileSever)
            : base(serviceProvider)
        {
            _userService = userService;
            _environment = environment;
            _purseService = purseService;
            _fileSever = fileSever;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model,PurseModel purseModel)
        {
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<User>(model);
                await _userService.CreateAsync(user);
                var purse = Mapper.Map<Purse>(purseModel);
                purseModel.UserId = user.Id;
                purse.UserId = user.Id;
                await _purseService.CreateAsync(purse);
            }
            return View(model);
        }
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
                //判断完用户名之后，判断密码是否相等
                if (user != null && user.Password == model.Password)
                {
                    Response.Cookies.Append("UserName", user.UserName);
                    Response.Cookies.Append("UserId", user.Id.ToString());
                    Response.Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码错误");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> UserProfile()
        {
            if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
            {
                return Redirect("/Account/Login");
            }
            var user = await _userService.GetByIdAsync(Convert.ToInt32(userIdValue));
            var profile = Mapper.Map<ProfileModel>(user);
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> UserProfile(ProfileModel model)
        {
            if (ModelState.IsValid)
            {
                if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
                {
                    return Redirect("/Account/Login");
                }
                var user = await _userService.GetByIdAsync(Convert.ToInt32(userIdValue));
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
        public async Task<IActionResult> UpdatePassword()
        {
            if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
            {
                return Redirect("/Account/Login");
            }
            var user = await _userService.GetByIdAsync(Convert.ToInt32(userIdValue));
            var profile = Mapper.Map<UpdatePasswordModel>(user);
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
                {
                    return Redirect("/Account/Login");
                }
                var user = await _userService.GetByIdAsync(Convert.ToInt32(userIdValue));
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
        public IActionResult SignOut()
        {
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("UserId");
            return RedirectToAction(nameof(Login));
        }
        public async Task<IActionResult> UploadAvator()
        {
            if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
            {
                return Redirect("/Account/Login");
            }
            var user = await _userService.GetByIdAsync(Convert.ToInt32(userIdValue));
            var avator = Mapper.Map<UploadAvatorModel>(user);
            return View(avator);
        }
        [HttpPost]
        public async Task<IActionResult> UploadAvator(UploadAvatorModel model)
        {
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
                        ModelState.AddModelError("", "上传图片格式不正确。");
                        return View(model);
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
                    if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
                    {
                        return Redirect("/Account/Login");
                    }
                    var user = await _userService.GetByIdAsync(Convert.ToInt32(userIdValue));
                    if (user == null)
                    {
                        return NotFound();
                    }
                    user.Avator = "/images/" + newFileName;
                    await _userService.UploadAvatorAsync(user);
                }
            }
            return RedirectToAction(nameof(UserProfile));
        }


   

    }
}

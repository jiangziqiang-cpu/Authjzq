using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagement.Web.Services;
using AuthorityManagement.Web.ViewModels.AccountViewModels;
using DotNetStudy.Web.Controllers;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Poseidon.Infrastructure;
using Poseidon.Infrastructure.Authorize;
using Poseidon.Web.Areas.Admin;

namespace AuthorityManagement.Web.Controllers
{
    [Authorize]
    [AuthorizeCheck(Pages.Authorization_User)]
    public class UserController : WebControllerBase
    {
        /// <summary>
        /// 人员服务
        /// </summary>
        private readonly UserService _userService;
        /// <summary>
        /// 角色服务
        /// </summary>
        private readonly RoleSever _roleSever;
        /// <summary>
        /// 文件
        /// </summary>
        private  IWebHostEnvironment _environment;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(UserService userService, RoleSever roleSever, IWebHostEnvironment environment, IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor) 
            : base(serviceProvider, httpContextAccessor)
        {
            _userService = userService;
            _roleSever = roleSever;
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

      
        [AuthorizeCheck(Pages.Authorization_User)]
        /// <summary>
        /// 展示所有用户
        /// </summary>
        /// <returns></returns>        
        public async Task<IActionResult> ShowAllUser()
        {
            var users = await _userService.GetAllUser();
            AccountViewModels models = new AccountViewModels();
            models.Roles = await _roleSever.GetRolesAsync();
            models.Users = users;
            return View(models);
        }
       
        [AuthorizeCheck(Pages.Authorization_User_Create)]
        [HttpPost]
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddUser(User user)
        {
            var a = Request.Form.Files;
            var user1 = UploadProfile(user);
            var roleNames = new List<string>();
            user.Password = Tools.GetMD5(user.Password);//密码进行加密
            foreach (var key in Request.Form.Keys)
            {
                if (key.Contains("Role.") && Request.Form[key].Contains("on"))
                {
                    roleNames.Add(key.Substring(5));
                }
            }
            await _userService.CreateAsync(user1, roleNames);
            return Redirect(nameof(ShowAllUser));
        }

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        [AuthorizeCheck(Pages.Authorization_User_Edit)]
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserViewModel user)
        {
            var roleNames = new List<string>();
            foreach (var key in Request.Form.Keys)
            {
                if (key.Contains("Role.") && Request.Form[key].Contains("on"))
                {
                    roleNames.Add(key.Substring(5));
                }
            }
            bool IsOk = false;
            var account = await _userService.GetByIdAsync(user.Id);
            if (!user.Password.IsNullOrEmpty())
            {
                user.Password = Tools.GetMD5(user.Password);//密码进行加密
            }
            else
            {
                user.Password = account.Password;
            }
            if (user.Password != account.Password && user.Id == UserIdForClims)
            {
                IsOk = true;
            }
            User user1 = Mapper.Map(user, account);
            var user2 = UploadProfile(user1);
            await _userService.UploadAvatorAsync(user2, roleNames);
            if (IsOk)
            {              
                await _httpContextAccessor.HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
                return RedirectToAction("Login", "Account");
            }
            return Redirect(nameof(ShowAllUser));
        }


      
        [HttpPost]
        /// <summary>
        /// 用户的启用和禁用
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> UserEnabledAndDisabled(int Id)
        {
            var user = await _userService.GetByIdAsync(Id);
            if (user.Active == 0)
            {
                user.Active = 1;
            }
            else
            {
                user.Active = 0;
            }
            await _userService.UploadAvatorAsync(user);
            return Redirect(nameof(ShowAllUser));
        }

        [AuthorizeCheck(Pages.Authorization_User_Delete)]
        /// <summary>
        /// 根据用户Id移除用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RomoveUser(int Id)
        {
            int isOk = await _userService.ReMoveUserById(Id);
            return Redirect(nameof(ShowAllUser));
        }

        private async Task<IActionResult> BuildDisplayAsync(AccountViewModels model)
        {
            if (model == null)
                model = new AccountViewModels();
            var roles = await _roleSever.GetRolesAsync();
            model.Roles = roles;
            return View(model);
        }

        [AuthorizeCheck(Pages.Authorization_User_Edit)]
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> EditUser(int Id)
        {         
            var user = await _userService.GetByIdAsync(Convert.ToInt32(Id));
            var model = Mapper.Map<AccountViewModels>(user);
            List<string> SelectedRoles = new List<string>();
            var roles = await _roleSever.GetRoleByUserId(Convert.ToInt32(Id));
            foreach (var item in roles)
            {
                SelectedRoles.Add(item.Name);
            }
            model.SelectedRoles = SelectedRoles;
            return await BuildDisplayAsync(model);

        }
    }
}

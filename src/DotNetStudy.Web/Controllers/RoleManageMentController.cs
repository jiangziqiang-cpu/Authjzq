using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthorityManagement.Web.Models;
using AuthorityManagement.Web.Services;
using AuthorityManagement.Web.ViewModels.Role;
using AutoMapper;
using DotNetStudy.Web.Controllers;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poseidon.Infrastructure;
using Poseidon.Infrastructure.Authorize;
using Poseidon.Web.Areas.Admin;

namespace AuthorityManagement.Web.Controllers
{
    [Authorize]
    //[AuthorizeCheck(Pages.Authorization_Role)]
    public class RoleManageMentController : WebControllerBase
    {

        private readonly RoleSever _roleSever;
        private readonly RoleClaimsSever _roleClaimsSever;
        private readonly UserRoleSever  _userRole;
  

        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleManageMentController(RoleSever roleSever, IServiceProvider serviceProvider,
            RoleClaimsSever roleClaimsSever, IHttpContextAccessor httpContextAccessor,
            UserRoleSever userRole) : base(serviceProvider, httpContextAccessor)
        {
            _roleSever = roleSever;
            _roleClaimsSever = roleClaimsSever;
            _httpContextAccessor = httpContextAccessor;
            _userRole = userRole;
        }

        public async Task<IActionResult> ShowRole()
        {

            var roles = await _roleSever.GetAllRole();
            ShowRole showRole = new ShowRole();
            showRole.ShowRoles = roles;
            return View(showRole);
        }

        [AuthorizeCheck(Pages.Authorization_Role_Create)]
        public async Task<IActionResult> AddRole()
        {

            return View(new AddAndEditRoleViewModels()
            {
                RolePermissions = RoleFictitious.ToList()
            });
        }

        [AuthorizeCheck(Pages.Authorization_Role_Create)]
        [HttpPost]
        public async Task<IActionResult> AddRole(AddAndEditRoleViewModels addRoleViewModels)
        {

            var role = Mapper.Map<Role>(addRoleViewModels);
            role.RoleClaims = new List<RoleClaims>();
            var roleNames = new List<string>();
            foreach (var key in Request.Form.Keys)
            {
                if (key.Contains("Permission.") && Request.Form[key].Contains("on"))
                {
                    roleNames.Add(key.Substring(11));
                }
            }
            List<RoleClaims> roleClaims1 = new List<RoleClaims>();
            foreach (var item in roleNames)
            {
                RoleClaims roleClaims2 = new RoleClaims();
                roleClaims2.ClaimType = "RoleClaims";
                roleClaims2.ClaimValue = item;
                role.RoleClaims.Add(roleClaims2);
            }
            await _roleSever.AddRole(role);
            return Redirect(nameof(ShowRole));
        }

        private void RecursivelyPermission(List<RoleFictitious> permissions, IList<Claim> roleClaims)
        {
            foreach (var permission in permissions)
            {
                var roleClaim = roleClaims.FirstOrDefault(f => f.Type == "RoleClaims" && f.Value == permission.Name);
                if (roleClaim != null)
                    permission.IsGrant = true;
                if (permission.Children.Count > 0)
                {
                    RecursivelyPermission(permission.Children.ToList(), roleClaims);
                }
            }
        }

        private void RecursivelyPermission(List<RoleFictitious> permissions, IList<RoleClaims> roleClaims)
        {
            foreach (var permission in permissions)
            {
                var roleClaim = roleClaims.FirstOrDefault(f => f.ClaimValue == permission.Name);
                if (roleClaim != null)
                    permission.IsGrant = true;
                if (permission.Children.Count > 0)
                {
                    RecursivelyPermission(permission.Children.ToList(), roleClaims);
                }
            }
        }

        [AuthorizeCheck(Pages.Authorization_Role_Edit)]
        public async Task<IActionResult> EditRole(int Id)
        {
            var role = await _roleSever.GetRoleByRoleId(Id);
            AddAndEditRoleViewModels addAndEditRoleViewModels = new AddAndEditRoleViewModels();
            var model = Mapper.Map<AddAndEditRoleViewModels>(role);
            var roleFictitious = RoleFictitious;
            model.RolePermissions = RoleFictitious.ToList();
            //var user=_httpContextAccessor.HttpContext.User;
            var claims = _roleClaimsSever.GetRoleClaims(new List<int>() { Id });
            RecursivelyPermission(model.RolePermissions, claims);
            return View(model);
        }
        /// <summary>
        /// 启用或禁用
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Active"></param>
        /// <returns></returns>
        public async Task<IActionResult> DisableOrEnable(int Id, string Active)
        {
            Role role = await _roleSever.GetRoleByRoleId(Id);//根据roleId得到角色
            if (Active == "启用")//判断是不是启用
            {
                role.Active = RoleEnum.禁用;
            }
            else
            {
                role.Active = RoleEnum.启用;
            }
            await _roleSever.DisableOrEnable(role);
            return Redirect(nameof(ShowRole));
        }

        [AuthorizeCheck(Pages.Authorization_Role_Edit)]
        [HttpPost]
        public async Task<IActionResult> UpdateRole(AddAndEditRoleViewModels role)
        {

            var role1 = Mapper.Map<Role>(role);
            await _roleSever.UpdateRole(role1);
            var roleNames = new List<string>();
            foreach (var key in Request.Form.Keys)
            {
                if (key.Contains("Permission.") && Request.Form[key].Contains("on"))
                {
                    roleNames.Add(key.Substring(11));
                }
            }
            var roleClaims = _roleClaimsSever.GetRoleClaims(new List<int>() { role1.Id });
            await _roleClaimsSever.Removes(roleClaims);
            List<RoleClaims> roleClaims1 = new List<RoleClaims>();
            foreach (var item in roleNames)
            {
                RoleClaims roleClaims2 = new RoleClaims();
                roleClaims2.RoleId = role1.Id;
                roleClaims2.ClaimType = "RoleClaims";
                roleClaims2.ClaimValue = item;
                roleClaims1.Add(roleClaims2);
            }
            await _roleClaimsSever.AddRoleClaims(roleClaims1);
            return Redirect(nameof(ShowRole));
        }

        [AuthorizeCheck(Pages.Authorization_Role_Delete)]
        public async Task<IActionResult> RemoveRole(int Id)
        {
            await _userRole.RemoveUserRoleByRoleId(Id);
            await _roleClaimsSever.RemoveClaimsByRoleId(Id);
            var role = await _roleSever.GetRoleByRoleId(Id);
            await _roleSever.RemoveRole(role);
            return Redirect(nameof(ShowRole));
        }


    }
}

using AuthorityManagement.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Poseidon.Infrastructure;
using Poseidon.Web.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DotNetStudy.Web.Controllers
{

    //[Area("Controllers")]
    public class WebControllerBase : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WebControllerBase(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
        {            
            Mapper = serviceProvider.GetService<IMapper>();
            _httpContextAccessor = httpContextAccessor;
        }

         
        public int? UserIdForClims
        {

            get
            {
                var userIdValue = User.FindFirst(AppConstants.UserIdentifier)?.Value;
                int userId;
                if (!int.TryParse(userIdValue, out userId))
                    return null;
                return userId;
            }
        }

        protected ClaimsPrincipal User
        {
            get
            {
                return _httpContextAccessor.HttpContext.User;
            }
        }
        protected IMapper Mapper { get; set; }

        protected IEnumerable<RoleFictitious> RoleFictitious { 
            get{
                Pages  page = new Pages();
                return page.GetPermissions();
               } 
        }

        public IEnumerable<RoleNavigation> GetNavigations
        { 
            get {
                Pages page = new Pages();
                return page.GetNavigations();
                } 
        }

        public int UserId
        {
            get
            {
                int _userId = 0;
                if (!(Request.Cookies.TryGetValue("UserId", out string userIdValue) && int.TryParse(userIdValue, out _userId)))
                {
                    Response.Redirect("");
                }
                return _userId;
            }
        }
    }
}

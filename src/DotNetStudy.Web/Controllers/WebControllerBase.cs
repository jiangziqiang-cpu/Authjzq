using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DotNetStudy.Web.Controllers
{
    public class WebControllerBase : Controller
    {
        public WebControllerBase(IServiceProvider serviceProvider)
        {
            Mapper = serviceProvider.GetService<IMapper>();
        }

        protected IMapper Mapper { get; set; }

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

using DotNetStudy.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Poseidon.Infrastructure;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Controllers
{
    [Authorize]
    public class HomeController : WebControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ILogger<HomeController> logger,
            IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor) : base(serviceProvider, httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

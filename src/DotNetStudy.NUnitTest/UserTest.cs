using DotNetStudy.Web.Data;
using DotNetStudy.Web.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace DotNetStudy.NUnitTest
{
    public class UserTest
    {
        UserService _userService;
        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddDbContext<StudyDbContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=StudyDb;Uid=sa;Password=sa;");
            });
            services.AddTransient<UserService>();
            var serviceProvider = services.BuildServiceProvider();
            _userService = serviceProvider.GetRequiredService<UserService>();
        }
        //[Test]
        //public void CreateUser()
        //{
        //    _userService.CreateAsync(new Web.Models.User()
        //    {
        //        UserName = "Administrator",
        //        Name = "Admin",
        //        Surname = ""
        //    }).Wait();
        //}

    }
}

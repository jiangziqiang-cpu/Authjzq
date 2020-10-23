using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alipay.AopSdk.AspnetCore;
using AuthorityManagement.Web.Services;
using DotNetStudy.Web.Data;
using DotNetStudy.Web.MappingProfiles;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Poseidon.Infrastructure.Alarms;
using Poseidon.Infrastructure.Authorize;

namespace DotNetStudy.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<StudyDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<UserService>();       
            services.AddTransient<AlipayService>();            
     
            services.AddTransient<UserRoleSever>();
            services.AddTransient<RoleSever>();
            services.AddTransient<RoleClaimsSever>();
            services.AddTransient<MenuSever>();            
            services.AddScoped<IAlarm, Alarm>();
            services.Configure<MvcOptions>((options) =>
            {
                options.Filters.Add(typeof(AlertFilter));
                options.Filters.Add(typeof(AuthorizationFilter));
            });
     


            services.AddMappingProfile();
            services.AddAlipay(options =>
            {
                options.IsKeyFromFile = false; 
                options.AlipayPublicKey = Configuration["Alipay:AlipayPublicKey"];
                options.AppId = Configuration["Alipay:AppId"];
                options.CharSet = Configuration["Alipay:CharSet"];
                options.Gatewayurl = Configuration["Alipay:Gatewayurl"];
                options.PrivateKey = Configuration["Alipay:PrivateKey"];
                options.SignType = Configuration["Alipay:SignType"]; 
                options.Uid = Configuration["Alipay:Uid"];
            });

            //services.AddAuthorization();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            })
             .AddCookie(IdentityConstants.ApplicationScheme, o =>
             {
                 o.LoginPath = new PathString("/Account/Login");
             });
            services.AddHttpContextAccessor();
        }
      

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

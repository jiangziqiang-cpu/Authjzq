using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alipay.AopSdk.AspnetCore;
using DotNetStudy.Web.Data;
using DotNetStudy.Web.MappingProfiles;
using DotNetStudy.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddTransient<MyAddressService>();
            services.AddTransient<PurseService>();
            services.AddTransient<GoodsService>();
            services.AddTransient<GoodsImgaeService>();
            services.AddTransient<GoodTypeService>();
            services.AddTransient<TradeService>();
            services.AddTransient<AlipayService>();
            services.AddTransient<CartService>();
            services.AddTransient<OrderService>();
            services.AddTransient<AlipayPaymentService>();
            services.AddTransient<FileSever>();
            services.AddTransient<OrderDetailSever>();
            






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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

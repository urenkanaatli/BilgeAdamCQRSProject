using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Identity;
using Infrastructure.Interface;

namespace BankAppXX.Web
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

            //EFCORE
            //EFCORE.SQLSERVER..
            //EFCORE.MEMORY...


            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUser, CurrentUser>();


            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddIdentity<ApplicationUser, IdentityRole>(t =>
            {
                t.Password.RequireDigit = true;
                t.Password.RequiredLength = 6;
                t.Password.RequireUppercase = true;

            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IdentitySeedData, IdentitySeedData>();


            //cookie bazlý býr autentication istiyorum.
            services.AddAuthentication();
            services.AddAuthorization(t =>
            {

                t.AddPolicy("AccountTransactionPoliciy", t =>
                {
                    t.RequireRole("Admin");
                    t.RequireClaim("statu", "5");

                });

            });

            services.ConfigureApplicationCookie(t =>
            {
                t.LoginPath = "/Account/Login";


            });



            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {





            //app.Run(async r =>
            //{

            //    int a = 20;

            //});




            //app.Use(async (context, next) =>
            //{

            //    await context.Response.WriteAsync("Middleware 1 calýstý");

            //    await next();

            //    await context.Response.WriteAsync("Middleware1 donus yolunda");


            //});


            //app.Map("/Detay", t =>
            //{

            //    app.Use(async (r,e) =>
            //    {

            //        await r.Response.WriteAsync("Detay sayfasýna hosgeldiniz");

            //    });

            //});



            app.UseExceptionMiddleWare();
            app.UsePerformanceMiddleWare();


            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();


         

            app.UseStaticFiles();

            app.UseRouting();

            //identity middlewares
            app.UseAuthentication();
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

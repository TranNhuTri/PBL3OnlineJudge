using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PBL3.Data;
using Microsoft.EntityFrameworkCore;
using PBL3.CustomHandler;
using Microsoft.AspNetCore.Authorization;
using PBL3.Features.ProblemManagement;
using PBL3.Repositories;
using PBL3.Features.SubmissionManagement;
using PBL3.Features.CategoryManagement;

namespace PBL3
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
            services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {
                     config.Cookie.Name = "UserLoginCookie"; // Name of cookie   
                     config.LoginPath = "/Login/UserLogin"; // Path for the redirect to user login page  
                     config.AccessDeniedPath = "/Login/AccessDenied";
                 });

            services.AddAuthorization();

            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();

            services.AddTransient(typeof(IRepository<>),typeof(GenericRepository<>));

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProblemService, ProblemService>();

            services.AddScoped<ISubmissionService, SubmissionService>();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();
            
            services.AddDbContext<PBL3Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PBL3Context")));

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseDefaultFiles();

            app.UseStaticFiles(); 
            
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

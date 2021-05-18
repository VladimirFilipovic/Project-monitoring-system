using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using ITSolutionsCompanyV1.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ITSolutionsCompanyV1.Models;
using UserService.Data;
using ITSolutionsCompanyV1.Data.Extensions;
using ITSolutionsCompanyV1.Service.ApplicationUserService;
using ITSolutionsCompanyV1.Repositories.ApplicationUserRepository;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Buffers;
using Microsoft.AspNetCore.Mvc;

namespace ITSolutionsCompanyV1
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
            services.AddEmployeesDbContext(Configuration);

            services.AddControllers()
     .AddNewtonsoftJson(options =>
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
 );

            services.AddScoped<IApplicationUserService, ApplicationUserService>();

            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
           
            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            MyIdentityDataInitializer.SeedUsersAndRoles(userManager, roleManager);
            app.ExecuteSqlScripts (Configuration,"Triggers");
            app.ExecuteSqlScripts(Configuration, "SeedData");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

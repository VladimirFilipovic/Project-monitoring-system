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
using ITSolutionsCompanyV1.Repositories.RequestRepository;
using ITSolutionsCompanyV1.Service.RequestsService;
using ITSolutionsCompanyV1.Repositories.ProjectRepository;
using ITSolutionsCompanyV1.Service.ProjectsService;
using AutoMapper;
using ITSolutionsCompanyV1.Service.TokenService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;

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

            services.AddControllers(opt => {
                var policy = new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
 );
            services.AddScoped<IApplicationUserService, ApplicationUserService>();

            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            services.AddAutoMapper(typeof(Startup).Assembly);

            //services.AddTransient<IRequestRepository, RequestRepository>();

            //services.AddTransient<IRequestsService, RequestsService>();
                
         

            services.AddScoped<IProjectsService, ProjectsService>();

            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<TokenService>();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
           
            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = key,
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });
            services.AddAuthorization();
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Events.OnRedirectToLogin = context =>
            //    {
            //        context.Response.Headers["Location"] = context.RedirectUri;
            //        context.Response.StatusCode = 401;
            //        return System.Threading.Tasks.Task.CompletedTask;
            //    };
            //});

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
     

            MyIdentityDataInitializer.SeedUsersAndRoles(userManager, roleManager);
            app.ExecuteSqlScripts (Configuration,"Triggers");
            app.ExecuteSqlScripts(Configuration, "SeedData");
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());



            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

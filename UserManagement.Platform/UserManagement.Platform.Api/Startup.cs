using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Platform.Contracts;
using UserManagement.Platform.Dal;
using UserManagement.Platform.Dal.Interfaces;
using UserManagement.Platform.Repo;

namespace UserManagement.Platform.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                 .AddMvcOptions(opt => { opt.EnableEndpointRouting = false; });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("UserManagement", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WebApi", Description = "User Management web api" });

            });

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddScoped<IUserQueries, UserQueries>(client =>
            {
                var connectionstring = this.Configuration.GetValue<string>("ConnectionString");
                return new UserQueries(connectionstring);
            });

            services.AddScoped<IGroupQueries, GroupQueries>(client =>
            {
                var connectionstring = this.Configuration.GetValue<string>("ConnectionString");
                return new GroupQueries(connectionstring);
            });


            services.AddScoped<IUserService, UserService>(c =>
            {
                var connectionstring = this.Configuration.GetValue<string>("ConnectionString");
                return new UserService(new UserQueries(connectionstring));
            });
            services.AddScoped<IGroupService, GroupService>(c =>
            {
                var connectionstring = this.Configuration.GetValue<string>("ConnectionString");
                return new GroupService(new GroupQueries(connectionstring));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var pathBase = this.Configuration["PATH_BASE"];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); app.UseSwagger()
                   .UseSwaggerUI(c => c.SwaggerEndpoint($"{(!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty)}/swagger/UserManagement/swagger.json", "UserManagement"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("CorsPolicy");
            app.UseMvcWithDefaultRoute();

        }
    }
}

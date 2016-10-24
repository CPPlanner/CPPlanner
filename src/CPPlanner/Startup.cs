﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Configuration;
using CPPlanner.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ClassTrack.Models;

namespace CPPlanner
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);

            services.AddDbContext<CPPlannerContext>();

            services.AddTransient<CPPlannerContextSeedData>();

            services.AddScoped<ICPPlannerRepository, CPPlannerRepository>();

            services.AddIdentity<CPPlannerUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";     // Forward user to url if not authorized                
            })
            .AddEntityFrameworkStores<CPPlannerContext>();

            services.AddMvc(config =>
            {
                if (_env.IsEnvironment("Production"))   // or _env.IsProduction(). This uses default. If you want to set your own prod env, use: ASPNETCORE_ENVIRONMENT=Production
                {
                    config.Filters.Add(new RequireHttpsAttribute());
                }
            })
            .AddJsonOptions(config =>
            {
                config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CPPlannerContextSeedData seeder, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Auth", action = "Login" }
                );
            });

            seeder.EnsureSeedData().Wait();     // asynchronously seed initial data to context
        }
    }
}

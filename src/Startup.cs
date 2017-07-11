﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TheWorld.Models;
using TheWorld.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;

namespace TheWorld
{
    public class Startup
    {
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment env, IConfiguration config)
        {
            _env = env;
            Configuration = config;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment() || _env.IsEnvironment("Testing"))
            {
                services.AddScoped<IMailService, DebugMailService>();
            }
            services.AddDbContext<WorldContext>();
            services.AddTransient<WorldContextSeedData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, WorldContextSeedData seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseBrowserLink();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=App}/{action=Index}/{id?}");
            });

            seeder.EnsureSeedData().Wait();
        }
    }
}

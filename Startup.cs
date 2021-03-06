﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_Services.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Demo_Services
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
            var password = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "ThisIsPass1@";
            //var connString = $"Data Source={hostname};Initial Catalog=QL_Sach;User ID=sa;Password={password};";
            var connString = $"Server=db;Initial Catalog=QL_Sach;User ID=sa;Password={password};";

            services.AddDbContext<QL_SachContext>(options => options.UseSqlServer(connString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

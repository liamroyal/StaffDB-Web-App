using StaffDatabase.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StaffDatabase
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Use SQLite in development and SQL Server for production
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<StaffDatabaseContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("StaffMemberContext")));

                services.AddMvc().AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute("/StaffDatabase/Pages/Staff/Create", "");

                });
            }
            else
            {   
                services.AddDbContext<StaffDatabaseContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("StaffMemberContext")));

                services.AddMvc().AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute("/Staff/Create", "");

                });
            }
            
            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

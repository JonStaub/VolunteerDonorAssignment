using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerDonorAssignment.Data;

namespace VolunteerDonorAssignment
{
    public class Startup
        //TODO: Use "use" and "run" for pair programming homework
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")) //Local SQL DB for testing purposes
            );

            services.AddDbContext<AzureSQLContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("AzureSQL"))
            );

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //Order of services matters!
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
            app.UseStaticFiles();

            app.UseRouting(); 
            //app.UseAuthentication(); //TODO: implement authentication for volunteers and employees
            app.UseAuthorization();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync("<h1>Whoops, that path didn't work. Don't panic!</h1>");
                await context.Response.WriteAsync("<a href='https://www.pexels.com/search/cute%20animals/'>Enjoy these cute animal photos while you wait</a>");
            });
        }
    }
}

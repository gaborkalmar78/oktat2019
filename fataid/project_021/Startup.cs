using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using project_021.DataBase;
using project_021.Models;

namespace project_021
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Category c1 = new Category();
            Category c2 = new Category("barmi");
            Category c3 = new Category("akarmi",new Topic[]{});
            Category c4 = new Category("semmi", new Topic(), new Topic());
            c1.Rename1();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var options = new DbContextOptionsBuilder<BlogContext>().UseInMemoryDatabase("Blog").Options;
            services.AddDbContext<BlogContext>();
            services.AddSingleton(options);
            services.Configure<CookiePolicyOptions>(o =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                o.CheckConsentNeeded = context => true;
                o.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

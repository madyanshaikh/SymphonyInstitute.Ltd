using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SymphonyInstitute.Ltd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SymphonyInstitute.Ltd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Authorization;
using SymphonyInstitute.Ltd.Common;

namespace SymphonyInstitute.Ltd
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

            services.AddAuthorization();

            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddMvc();
            services.AddDbContext<StudentDbContext>(x => x.UseSqlServer("server=.;database=symphonyinstitute.ltd;integrated security=true;"));
            //services.AddDbContext<StudentDbContext>(x => x.
            //UseSqlServer(Global.ConnectionString = Configuration.GetConnectionString("SymphonyInstitute.Ltd")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<StudentDbContext>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(a => a.LoginPath = "/accounts/login");
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPricipalFactory>();

            services.Configure<IdentityOptions>(x =>
            {
                //x.Password.RequireDigit = false;
                //x.SignIn.RequireConfirmedEmail = true;
                //x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //x.Lockout.MaxFailedAccessAttempts = 3;
            });

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
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

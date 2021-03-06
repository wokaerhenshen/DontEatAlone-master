﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.DependencyInjection;
using DontEatAlone.Data;
using DontEatAlone.Models;
using DontEatAlone.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace DontEatAlone
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /*
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Premium", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
        */

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));


            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(600);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(
                    config =>
                    {
                        config.SignIn.RequireConfirmedEmail = false;
                    }
                )
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            //Lockout Settings 
            services.Configure<IdentityOptions>(options =>
            {

                //// Password settings if you want to ensure password strength. EDIT PASSWORD AUTHENTICATION HERE
                //options.Password.RequireDigit           = true;
                //options.Password.RequiredLength         = 8;
                //options.Password.RequireNonAlphanumeric = false;
                //options.Password.RequireUppercase       = true;
                //options.Password.RequireLowercase       = false;
                //options.Password.RequiredUniqueChars    = 6;

                // Lockout settings (Freeze 1 minute only to make testing easier)
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 3; // Lock after 3 consec failed logins
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;


            });


            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

            services.AddMvc();
            services.Configure<AuthMessageSenderOptions>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
                //   builder.AddUserSecrets<Startup>();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseCors("AllowAll");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);

        }
    }
}

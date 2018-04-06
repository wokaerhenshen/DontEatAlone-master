using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using DontEatAlone.Data;
using DontEatAlone.Repo;
using Microsoft.AspNetCore.Identity;
using DontEatAlone.Models;

namespace DontEatAlone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args); // Revised to enable seeding.

            // Seed the data when the application starts.
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<Models.ApplicationUser>>();
                    IServiceProvider serviceProvider = services.GetRequiredService<IServiceProvider>();
                    Initialize initializer = new Initialize(context, userManager);
                    //initializer.InitializeData();
                    RoleRepo roleIni = new RoleRepo(context);
                    roleIni.CreateInitialRoles();
                    Initialize DataIni = new Initialize(context, userManager);

                    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    string[] roleNames = { "Admin", "Premium", "Member" };
                    Task<IdentityResult> roleResult;

                    foreach (var roleName in roleNames)
                    {
                        var roleExist = RoleManager.Roles.Where(r => r.Name == roleName).FirstOrDefault();
                        if (roleExist != null)
                        {
                            //create the roles and seed them to the database: Question 1
                            roleResult = RoleManager.CreateAsync(new IdentityRole(roleName));
                        }
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }

            }
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

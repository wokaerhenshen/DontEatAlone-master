﻿using DontEatAlone.Data;
using DontEatAlone.Models;
using DontEatAlone.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Repo
{
    public class UserRoleRepository
    {
        IServiceProvider serviceProvider;
        ApplicationDbContext _context;

        public UserRoleRepository(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            this.serviceProvider = serviceProvider;
            this._context = context;
        }

        // Assign a role to a user.
        public async Task<bool> AddUserRole(string email, string roleName)
        {
            var UserManager = serviceProvider
                                .GetRequiredService<UserManager<ApplicationUser>>();
            var user = await UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                _context.UserRoles.Add(new IdentityUserRole<string>() {
                    UserId= user.Id,
                    RoleId = roleName
                });
                _context.SaveChanges();
                await UserManager.AddToRoleAsync(user, roleName);
            }
            return true;
        }

        // Remove role from a user.
        public async Task<bool> RemoveUserRole(string email, string roleName)
        {
            var UserManager = serviceProvider
                                .GetRequiredService<UserManager<ApplicationUser>>();
            var user = await UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                //_context.UserRoles.Remove(_context.UserRoles.Where(i => i.UserId == user.Id && i.RoleId == roleName).FirstOrDefault());
                //_context.SaveChanges();
                await UserManager.RemoveFromRoleAsync(user, roleName);
            }
            return true;
        }

        // Get all roles of a specific user.
        public async Task<IEnumerable<RoleVM>> GetUserRoles(string email)
        {
            var UserManager = serviceProvider
                                .GetRequiredService<UserManager<ApplicationUser>>();
            var user = await UserManager.FindByEmailAsync(email);
            var roles = await UserManager.GetRolesAsync(user);
            List<RoleVM> roleVMObjects = new List<RoleVM>();
            foreach (var item in roles)
            {
                roleVMObjects.Add(new RoleVM() { Id = item, RoleName = item });
            }
            return roleVMObjects;
        }

    }
}

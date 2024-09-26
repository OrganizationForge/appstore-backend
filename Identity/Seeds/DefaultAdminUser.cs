﻿using Application.Common.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Seeds
{
    public static class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //LLenamos el User Admin por defecto
            var defaultUser = new ApplicationUser
            {
                UserName = "userAdmin",
                Email = "userAdmin@gmail.com",
                Nombre = "Matias",
                Apellido = "Giraudo",
                EmailConfirmed= true,
                PhoneNumberConfirmed= true
            };

            if(userManager.Users.All(u => u.Id != defaultUser.Id) )
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null) {
                    await userManager.CreateAsync(defaultUser, "P4ssw0rd!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }
            }
        }
    }
}
using Application.Common.Enums;
using Identity.Context;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IdentityContext context)
        {
            if (!context.Users.Any())
            {
                //LLenamos el User Admin por defecto
                var adminUser = new ApplicationUser
                {
                    UserName = "userAdmin",
                    Email = "userAdmin@gmail.com",
                    Nombre = "Matias",
                    Apellido = "Giraudo",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                if (userManager.Users.All(u => u.Id != adminUser.Id))
                {
                    var user = await userManager.FindByEmailAsync(adminUser.Email);
                    if (user == null)
                    {
                        await userManager.CreateAsync(adminUser, "P4ssw0rd!");
                        await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());
                        await userManager.AddToRoleAsync(adminUser, Roles.Basic.ToString());
                    }
                }

                //LLenamos el User basico por defecto
                var basicUser = new ApplicationUser
                {
                    UserName = "userBasic",
                    Email = "userBasic@gmail.com",
                    Nombre = "Pepito",
                    Apellido = "Lopez",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                if (userManager.Users.All(u => u.Id != basicUser.Id))
                {
                    var user = await userManager.FindByEmailAsync(basicUser.Email);
                    if (user == null)
                    {
                        await userManager.CreateAsync(basicUser, "P4ssw0rd!");
                        await userManager.AddToRoleAsync(basicUser, Roles.Basic.ToString());
                    }
                }
            }
        }
    }
}

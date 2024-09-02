using Application.Common.Enums;
using Identity.Context;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IdentityContext context)
        {
            if (!context.UserRoles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
            }
        }
    }
}

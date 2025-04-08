using Microsoft.AspNetCore.Identity;
using PharmacyApp.Constants;

namespace PharmacyApp.Data
{
    public  class RoleSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var rolemanager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (!await rolemanager.RoleExistsAsync(Roles.Admin))
            {
                await  rolemanager.CreateAsync(new IdentityRole(Roles.Admin));
            }
            if (!await rolemanager.RoleExistsAsync(Roles.Customer))
            {
                await rolemanager.CreateAsync(new IdentityRole(Roles.Customer));
            }

        }
    }
}

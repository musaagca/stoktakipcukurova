using Microsoft.AspNetCore.Identity;
using YemekhaneStokTakipV2.Models;

namespace YemekhaneStokTakipV2.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (!await roleManager.RoleExistsAsync("Yonetici"))
            {
                await roleManager.CreateAsync(new IdentityRole("Yonetici"));
            }

            var user = await userManager.FindByNameAsync("admin");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@stoktakip.com"
                };

                var result = await userManager.CreateAsync(user, "1234");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Yonetici");
                }
            }
        }
    }
}
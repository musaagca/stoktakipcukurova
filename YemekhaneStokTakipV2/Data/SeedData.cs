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

            // Roller
            if (!await roleManager.RoleExistsAsync("Yonetici"))
            {
                await roleManager.CreateAsync(new IdentityRole("Yonetici"));
            }

            if (!await roleManager.RoleExistsAsync("Personel"))
            {
                await roleManager.CreateAsync(new IdentityRole("Personel"));
            }

            // Admin hesabı
            var admin = await userManager.FindByNameAsync("admin");

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@stoktakip.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, "1234");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Yonetici");
                }
            }

            // Personel hesabı
            var personel = await userManager.FindByNameAsync("personel");

            if (personel == null)
            {
                personel = new ApplicationUser
                {
                    UserName = "personel",
                    Email = "personel@stoktakip.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(personel, "1234");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(personel, "Personel");
                }
            }
        }
    }
}
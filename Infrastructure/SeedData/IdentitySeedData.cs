using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public class IdentitySeedData
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentitySeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedUserDataAsync()
        {


            IdentityRole identityRole = await roleManager.FindByNameAsync("Admin");

            if (identityRole == null)
            {

                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }


            ApplicationUser user = await userManager.FindByEmailAsync("uren@uren.com");

            if (user == null)
            {
                IdentityResult result = await userManager.CreateAsync(new ApplicationUser
                {
                    Email = "uren@uren.com",
                    UserName = "uren"
                }, "Password1!");

            }


            ApplicationUser userAdmin = await userManager.FindByEmailAsync("admin@admin.com");

            if (userAdmin == null)
            {
                var userNew = new ApplicationUser
                {
                    Email = "admin@admin.com",
                    UserName = "admin1"
                };

                IdentityResult result = await userManager.CreateAsync(userNew, "Password1!");

                await userManager.AddToRoleAsync(userNew, "Admin");
                await userManager.AddClaimAsync(userNew, new System.Security.Claims.Claim("statu", "4"));

            }


            ApplicationUser userAdmin2 = await userManager.FindByEmailAsync("admin2@admin.com");

            if (userAdmin2 == null)
            {
                var userNew = new ApplicationUser
                {
                    Email = "admin2@admin.com",
                    UserName = "admin2"
                };

                IdentityResult result = await userManager.CreateAsync(userNew, "Password1!");

                await userManager.AddToRoleAsync(userNew, "Admin");

                await userManager.AddClaimAsync(userNew, new System.Security.Claims.Claim("statu", "5"));

            }

        }
    }
}

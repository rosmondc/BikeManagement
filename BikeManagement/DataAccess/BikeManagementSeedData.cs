using BikeManagement.DataAccess.Models;
using BikeManagement.DataAccess.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeManagement.DataAccess
{
    public static class BikeManagementSeedData
    {
        public static void EnsureDataSeed(this BikeManagementDataContext db,
            UserManager<IdentityUser> userManager,
            RoleManager<CustomIdentityRole> roleManager)
        {

            if (!roleManager.RoleExistsAsync("Staff").Result)
            {
                CustomIdentityRole role = new CustomIdentityRole();
                role.Name = "Staff";
                role.Description = "Perform normal operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Owner").Result)
            {
                CustomIdentityRole role = new CustomIdentityRole();
                role.Name = "Owner";
                role.Description = "Perform admin operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!db.Users.Any(u => u.UserName == "Owner"))
            {
                var model = new UserViewModel { UserName = "Owner", Password = "OwnerPassword" };
                var user = new IdentityUser
                {
                    UserName = model.UserName,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = userManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Owner").Wait();
                }



                model = new UserViewModel { UserName = "Staff", Password = "StaffPassword" };
                user = new IdentityUser
                {
                    UserName = model.UserName,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                result = userManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Staff").Wait();
                }
            }




            if (!db.Bikes.Any())
            {
                var bikes = new List<Bike> { 
                                new Bike { Description = "Bike 1" }, 
                                new Bike { Description = "Bike 2" },
                                new Bike { Description = "Bike 3" } 
                            };

                db.Bikes.AddRange(bikes);
                db.SaveChanges();
            }

        }
    }
}
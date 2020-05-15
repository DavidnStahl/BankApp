using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibary.Models;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Models
{
    public class DatabaseInitializer
    {
        public void Initialize(BankAppDataContext context)
        {
            //context.Database.EnsureCreated();
            context.Database.Migrate();
            SeedData(context);
        }

        public void InitializeBankApp(BankAppDataContext context, UserManager<IdentityUser> userManager)
        {
            context.Database.Migrate();
            SeedDataIdentity(context, userManager);
            SeedData(context);
        }

        private void SeedData(BankAppDataContext context)
        {
            
            if (!context.BatchStatus.Any(r => r.LastId > 0))
                context.BatchStatus.Add(new BatchStatus { LastId = 1 });

            if(context.MobileAppUsers.Count() == 0)
            {
                context.MobileAppUsers.Add(new MobileAppUsers
                {
                    Username = "Stefan1",
                    Password = "Hejsan123#",
                    CustomerId = 1
                });

                context.MobileAppUsers.Add(new MobileAppUsers
                {
                    Username = "Stefan2",
                    Password = "Hejsan123#",
                    CustomerId = 2
                });

                context.MobileAppUsers.Add(new MobileAppUsers
                {
                    Username = "Stefan3",
                    Password = "Hejsan123#",
                    CustomerId = 3
                });

                context.MobileAppUsers.Add(new MobileAppUsers
                {
                    Username = "Stefan4",
                    Password = "Hejsan123#",
                    CustomerId = 4
                });

                context.MobileAppUsers.Add(new MobileAppUsers
                {
                    Username = "Stefan5",
                    Password = "Hejsan123#",
                    CustomerId = 5
                });
            }

            context.SaveChanges();

        }

        private void SeedDataIdentity(BankAppDataContext context, UserManager<IdentityUser> userManager)
        {
            AddRoleIfNotExists(context, "Admin");
            AddRoleIfNotExists(context, "Cashier");

            AddIfNotExists(userManager, "stefan.holmberg@nackademin.se", "Cashier");
            AddIfNotExists(userManager, "stefan.holmberg@systementor.se", "Admin");

        }
        private void AddRoleIfNotExists(BankAppDataContext context, string role)
        {
            if (context.Roles.Any(r => r.Name == role)) return;
            context.Roles.Add(new IdentityRole { Name = role, NormalizedName = role });
            context.SaveChanges();
        }

        private void AddIfNotExists(UserManager<IdentityUser> userManager, string user, string role)
        {
            if (userManager.FindByEmailAsync(user).Result == null)
            {
                var u = new IdentityUser
                {
                    UserName = user
                };

                var result = userManager.CreateAsync(u, "Hejsan123#").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(u, role).Wait();
                }
            }
        }
    }
}

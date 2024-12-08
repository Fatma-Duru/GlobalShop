using GlobalShop.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace GlobalShop.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            // Roller
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context); // RoleStore için IdentityRole tipi kullanıldı
                var manager = new RoleManager<ApplicationRole>(store); // RoleManager için IdentityRole tipi kullanıldı
                var role = new ApplicationRole()
                {
                    Name = "admin",
                    Description = "admin rolü",

                };
                manager.Create(role);

            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole()
                {
                    Name = "user",
                    Description="user rolü"
                };
                manager.Create(role);

            }
            if (!context.Users.Any(i => i.Name == "fatmaduru"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "fatma",
                    Surname = "duru",
                    UserName = "fatmaduru",
                    Email = "fatmaduru@gmail.com",

                };
                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");

            }
            if (!context.Users.Any(i => i.Name == "cengizduru"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "cengiz",
                    Surname = "duru",
                    UserName = "cengizduru",
                    Email = "cengizduru@gmail.com",

                };
                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");

            }

            // Kullanıcı

            base.Seed(context);
        }
    }
}

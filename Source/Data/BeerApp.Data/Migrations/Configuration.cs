namespace BeerApp.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //var hasUsers = context.Users.Any();
            //var hasBeerTypes = context.BeerTypes.Any();
            //var hasCountries = context.Countries.Any();
            //var hasBeers = context.Beers.Any();
            //var hasPlaces = context.Places.Any();
            //var hasRecipes = context.Recipes.Any();
            //var hasComments = context.Comments.Any();
            //var hasVotes = context.BeerVotes.Any();

            //if (!hasUsers
            //    || !hasBeerTypes
            //    || !hasCountries
            //    || !hasBeers
            //    || !hasPlaces
            //    || !hasRecipes
            //    || !hasComments
            //    || !hasVotes)
            //{
            //    var createdUsers = new List<ApplicationUser>();
            //    if (!hasUsers)
            //    {
            //        var userSeed = new SeedData();
            //        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //        if (!roleManager.Roles.Any())
            //        {
            //            roleManager.Create(new IdentityRole { Name = "Admin" });
            //        }

            //        context.SaveChanges();

            //        var adminUser = userManager.Users.FirstOrDefault(x => x.Email == "ahansb@ahansb.com");

            //        if (adminUser == null)
            //        {
            //            var admin = new ApplicationUser()
            //            {
            //                Email = "ahansb@ahansb.com",
            //                UserName = "ahansb",
            //                FirstName = "Admin",
            //                LastName = "Admin",
            //                ProfilePhotoUrl = "~/Content/SiteImages/default-profile-picture.jpg"
            //            };

            //            userManager.Create(admin, "adminAHANSB");
            //            userManager.AddToRole(admin.Id, "Admin");
            //            context.SaveChanges();
            //            createdUsers.Add(admin);
            //        }

            //        for (int i = 0; i < userSeed.Users.Count; i++)
            //        {
            //            userManager.Create(userSeed.Users[i], userSeed.UsersPasswords[i]);
            //            context.SaveChanges();
            //            createdUsers.Add(userSeed.Users[i]);
            //        }

            //        context.SaveChanges();
            //    }
            //    else
            //    {
            //        createdUsers = context.Users.ToList();
            //    }

            //    var seed = new SeedData(createdUsers);

            //    if (!hasBeerTypes)
            //    {
            //        seed.BeerTypes.ForEach(x => context.BeerTypes.Add(x));
            //        context.SaveChanges();
            //    }

            //    if (!hasCountries)
            //    {
            //        seed.Countries.ForEach(x => context.Countries.Add(x));
            //        context.SaveChanges();
            //    }

            //    if (!hasBeers)
            //    {
            //        seed.Beers.ForEach(x => context.Beers.Add(x));
            //        context.SaveChanges();
            //    }

            //    if (!hasPlaces)
            //    {
            //        seed.Places.ForEach(x => context.Places.Add(x));
            //        context.SaveChanges();
            //    }

            //    if (!hasRecipes)
            //    {
            //        seed.Recipes.ForEach(x => context.Recipes.Add(x));
            //        context.SaveChanges();
            //    }

            //    if (!hasComments)
            //    {
            //        seed.Comments.ForEach(x => context.Comments.Add(x));
            //        context.SaveChanges();
            //    }

            //    if (!hasVotes)
            //    {
            //        seed.BeerVotes.ForEach(x => context.BeerVotes.Add(x));
            //        context.SaveChanges();
            //    }
            //}
        }
    }
}

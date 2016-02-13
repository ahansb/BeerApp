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
            if (context.BeerTypes.Any())
            {
                return;
            }

            var userSeed = new SeedData();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var createdUsers = new List<ApplicationUser>();
            for (int i = 0; i < userSeed.Users.Count; i++)
            {
                userManager.Create(userSeed.Users[i], userSeed.UsersPasswords[i]);
                context.SaveChanges();
                createdUsers.Add(userSeed.Users[i]);
            }

            context.SaveChanges();

            var seed = new SeedData(createdUsers);

            seed.BeerTypes.ForEach(x => context.BeerTypes.Add(x));
            context.SaveChanges();

            seed.Countries.ForEach(x => context.Countries.Add(x));
            context.SaveChanges();

            seed.Beers.ForEach(x => context.Beers.Add(x));
            context.SaveChanges();

            // TODO: Fix exception
            seed.Places.ForEach(x => context.Places.Add(x));
            context.SaveChanges();

            seed.Recipes.ForEach(x => context.Recipes.Add(x));
            context.SaveChanges();
        }
    }
}

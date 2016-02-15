namespace BeerApp.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;


    public class SeedData
    {
        public static Random Rand = new Random();

        public List<ApplicationUser> Users;

        public List<string> UsersPasswords;

        public List<Beer> Beers;

        public List<BeerType> BeerTypes;

        public List<Comment> Comments;

        public List<Country> Countries;

        public List<Place> Places;

        public List<Recipe> Recipes;

        public SeedData()
        {
            // Addig Users na UserPasswords
            Users = new List<ApplicationUser>();
            UsersPasswords = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Users.Add(new ApplicationUser()
                {
                    Email = "user" + (i + 1) + "@user.com",
                    UserName = "username" + (i + 1),
                    FirstName = "UserFn" + (i + 1),
                    LastName = "UserLn" + (i + 1)
                });
                UsersPasswords.Add("password" + (i + 1));
            }

        }

        public SeedData(List<ApplicationUser> createdUsers)
        {
            // Adding BeerTypes
            BeerTypes = new List<BeerType>();
            BeerTypes.Add(new BeerType() { Name = "Lager" });
            BeerTypes.Add(new BeerType() { Name = "Red Lager" });
            BeerTypes.Add(new BeerType() { Name = "Pale Lager" });
            BeerTypes.Add(new BeerType() { Name = "Light Lager" });
            BeerTypes.Add(new BeerType() { Name = "Dark Lager" });
            BeerTypes.Add(new BeerType() { Name = "Ale" });
            BeerTypes.Add(new BeerType() { Name = "Pale Ale" });
            BeerTypes.Add(new BeerType() { Name = "Black Ale" });
            BeerTypes.Add(new BeerType() { Name = "Brown Ale" });
            BeerTypes.Add(new BeerType() { Name = "Blonde Ale" });
            BeerTypes.Add(new BeerType() { Name = "Export Lager" });
            BeerTypes.Add(new BeerType() { Name = "Pilsner" });
            BeerTypes.Add(new BeerType() { Name = "Stout" });
            BeerTypes.Add(new BeerType() { Name = "Porter" });
            BeerTypes.Add(new BeerType() { Name = "Kvass" });

            //Adding Countries
            Countries = new List<Country>();
            Countries.Add(new Country() { Name = "Bulgaria" });
            Countries.Add(new Country() { Name = "Germany" });
            Countries.Add(new Country() { Name = "USA" });
            Countries.Add(new Country() { Name = "UK" });
            Countries.Add(new Country() { Name = "Czech Republik" });

            // Adding Beers
            Beers = new List<Beer>();
            for (int i = 0; i < 50; i++)
            {
                var countryId = Rand.Next(0, 5);
                var beerTypeId = Rand.Next(0, 15);
                Beers.Add(new Beer()
                {
                    Name = "Beer" + (i + 1),
                    BeerTypeId = beerTypeId,
                    Type = BeerTypes[beerTypeId],
                    CoutryId = countryId,
                    Country = Countries[countryId],
                    Description = i.ToString() + " Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.",
                    ProducedSince = 2016 - Rand.Next(5, 100),
                    AlcoholContaining = 5 - (Rand.Next(0, 10) / (decimal)10)
                });
            }

            // Adding Places
            Places = new List<Place>();
            for (int i = 0; i < 10; i++)
            {
                var countryId = Rand.Next(0, 5);
                var user = createdUsers[Rand.Next(0, 5)];
                var userId = user.Id;

                Places.Add(new Place()
                {
                    Name = "Place" + (i + 1),
                    Type = (PlaceType) Rand.Next(0, 2),
                    CoutryId = countryId,
                    Country = Countries[countryId],
                    City = "City" + (i + 1),
                    Address = "Address" + (i + 1),
                    Phone = "08888888" + i,
                    CreatorId = userId,
                    Creator = user,
                    Beers = this.Beers.GetRange(Rand.Next(0, 40), Rand.Next(0, 9))
                });
            }

            // Adding Recipes
            Recipes = new List<Recipe>();
            for (int i = 0; i < 5; i++)
            {
                var user = createdUsers[Rand.Next(0, 5)];
                var userId = user.Id;
                Recipes.Add(new Recipe()
                {
                    BeerTypeId = Rand.Next(0, 15),
                    Title = "Recipe Title" + (i + 1),
                    CreatorId = userId,
                    Creator = user
                });
            }

        }
    }
}

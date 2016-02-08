namespace BeerCatalogue.Web
{
    using Data;
    using System.Data.Entity;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BeerCatalogueDbContext, Configuration>());

            BeerCatalogueDbContext.Create().Database.Initialize(true);
        }
    }
}
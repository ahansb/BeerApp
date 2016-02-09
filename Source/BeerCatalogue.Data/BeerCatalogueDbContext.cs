namespace BeerCatalogue.Data
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BeerCatalogueDbContext : IdentityDbContext<User>
    {
        public BeerCatalogueDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BeerCatalogueDbContext Create()
        {
            return new BeerCatalogueDbContext();
        }
    }
}

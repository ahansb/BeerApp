namespace BeerCatalogue.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;
    public class BeerCatalogueDbContext : IdentityDbContext<User>,IBeerCatalogueDbContext
    {
        public BeerCatalogueDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public virtual IDbSet<Beer> Beers { get; set; }

        public virtual IDbSet<Bar> Bars { get; set; }

        public virtual IDbSet<Store> Stores { get; set; }

        public static BeerCatalogueDbContext Create()
        {
            return new BeerCatalogueDbContext();
        }
    }
}

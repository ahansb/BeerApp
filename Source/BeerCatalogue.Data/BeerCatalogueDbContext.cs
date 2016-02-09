namespace BeerCatalogue.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    public class BeerCatalogueDbContext : IdentityDbContext<User>, IBeerCatalogueDbContext
    {
        public BeerCatalogueDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Beer> Beers { get; set; }

        public virtual IDbSet<BeerType> BeerTypes { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Place> Places { get; set; }

        public static BeerCatalogueDbContext Create()
        {
            return new BeerCatalogueDbContext();
        }
        //TODO:Check beers - places ralations
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>()
                 .HasMany<Beer>(p => p.Beers)
                 .WithMany(b => b.Places)
                 .Map(bp =>
                 {
                     bp.MapLeftKey("PlaceRefId");
                     bp.MapRightKey("BeerRefId");
                     bp.ToTable("PlaceBeer");
                 });

            modelBuilder.Entity<Place>()
                .HasRequired(p => p.Beers)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}

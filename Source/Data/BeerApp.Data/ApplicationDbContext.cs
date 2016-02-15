namespace BeerApp.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    using BeerApp.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Beer> Beers { get; set; }

        public IDbSet<BeerType> BeerTypes { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Place> Places { get; set; }

        public IDbSet<Recipe> Recipes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            //modelBuilder.Entity<Place>()
            //       .HasRequired(p => p.Beers)
            //       .WithMany()
            //       .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Beer>()
            //        .HasRequired(b => b.Places)
            //        .WithMany()
            //        .WillCascadeOnDelete(false);


            //modelBuilder.Entity<Place>()
            //            .HasMany<Beer>(p => p.Beers)
            //            .WithMany(b => b.Places)
            //            .Map(bp =>
            //            {
            //                bp.MapLeftKey("PlaceRefId");
            //                bp.MapRightKey("BeerRefId");
            //                bp.ToTable("BeerPlaces");
            //            });

            //modelBuilder.Entity<Place>()
            //        .HasRequired(p => p.Beers)
            //        .WithMany()
            //        .WillCascadeOnDelete(false);
        //    base.OnModelCreating(modelBuilder);
        //}

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo) entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}

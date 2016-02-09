namespace BeerCatalogue.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using BeerCatalogue.Models;

    public interface IBeerCatalogueDbContext:IDisposable
    {
        int SaveChanges();

        IDbSet<Beer> Beers { get; set; }

        IDbSet<BeerType> BeerTypes { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Place> Places { get; set; }
        
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}

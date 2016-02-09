namespace BeerCatalogue.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using BeerCatalogue.Models;

    public interface IBeerCatalogueDbContext:IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Beer> Beers { get; set; }

        IDbSet<Bar> Bars { get; set; }

        IDbSet<Store> Stores { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}

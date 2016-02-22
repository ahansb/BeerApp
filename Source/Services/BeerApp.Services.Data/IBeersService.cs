﻿namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Models;

    public interface IBeersService
    {
        IQueryable<Beer> GetAll();

        Beer GetById(string id);

        int Add(Beer beer);

        void Update(Beer beer);

        void Delete(Beer beer);

        int AdminCreate(Beer entity);
        
        void AdminUpdate(Beer entity);

        void AdminDestroy(int id);
        
        void AdminDispose();

    }
}

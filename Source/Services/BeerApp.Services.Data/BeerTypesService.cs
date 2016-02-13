namespace BeerApp.Services.Data
{
    using System;
    using System.Linq;
    using BeerApp.Data.Common;
    using BeerApp.Data.Models;

    public class BeerTypesService : IBeerTypesService
    {
        private readonly IDbRepository<BeerType> beerTypes;

        public BeerTypesService(IDbRepository<BeerType> beerTypes)
        {
            this.beerTypes = beerTypes;
        }

        public IQueryable<BeerType> GetAll()
        {
            return this.beerTypes.All();
        }
    }
}

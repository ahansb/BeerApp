namespace BeerApp.Services.Data
{
    using System;
    using System.Linq;
    using BeerApp.Data.Common;
    using BeerApp.Data.Models;
    using Web;

    public class BeersService : IBeersService
    {
        private readonly IDbRepository<Beer> beers;
        private readonly IIdentifierProvider identifierProvider;

        public BeersService(IDbRepository<Beer> beers, IIdentifierProvider identifierProvider)
        {
            this.beers = beers;
            this.identifierProvider = identifierProvider;
        }

        public int Add(Beer beer)
        {
            this.beers.Add(beer);
            this.beers.Save();
            return beer.Id;
        }

        public IQueryable<Beer> GetAll()
        {
           return this.beers.All();
        }

        public Beer GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var beer = this.beers.GetById(intId);

            return beer;
        }
    }
}

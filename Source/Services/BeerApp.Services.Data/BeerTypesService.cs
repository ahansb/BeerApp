namespace BeerApp.Services.Data
{
    using System;
    using System.Linq;
    using BeerApp.Data.Common;
    using BeerApp.Data.Models;
    using Web;

    public class BeerTypesService : IBeerTypesService
    {
        private readonly IDbRepository<BeerType> beerTypes;
        private readonly IIdentifierProvider identifierProvider;

        public BeerTypesService(IDbRepository<BeerType> beerTypes, IIdentifierProvider identifierProvider)
        {
            this.beerTypes = beerTypes;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<BeerType> GetAll()
        {
            return this.beerTypes.All();
        }

        public BeerType GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var beerType = this.beerTypes.GetById(intId);

            return beerType;
        }

        public IQueryable<BeerType> GetRandom(int count)
        {
            return this.beerTypes.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }
    }
}

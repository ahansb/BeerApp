namespace BeerApp.Services.Data
{
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

        public Beer GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var beer = this.beers.GetById(intId);

            return beer;
        }
    }
}

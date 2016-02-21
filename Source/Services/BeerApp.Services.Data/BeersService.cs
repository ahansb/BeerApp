namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Common.Repositories.Contracts;
    using BeerApp.Data.Models;
    using Web;

    public class BeersService : IBeersService
    {
        private readonly IDbRepository<Beer> beers;
        private readonly IIdentifierProvider identifierProvider;
        private readonly IDeletableEntityRepository<Beer> deleteableRepo;

        public BeersService(IDbRepository<Beer> beers, IIdentifierProvider identifierProvider, IDeletableEntityRepository<Beer> deleteableRepo)
        {
            this.beers = beers;
            this.identifierProvider = identifierProvider;
            this.deleteableRepo = deleteableRepo;
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

        public void Update(Beer beer)
        {
            var beerForModification = this.beers.GetById(beer.Id);
            beerForModification = beer;
            this.beers.Save();
        }

        public void Delete(Beer beer)
        {
            this.beers.Delete(beer);
            this.beers.Save();
        }

        public void Dispose()
        {
            this.deleteableRepo.Dispose();
        }
    }
}

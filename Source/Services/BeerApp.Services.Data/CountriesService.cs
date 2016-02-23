namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Common.Repositories.Contracts;
    using BeerApp.Data.Models;
    using Web;

    // TODO: Extract from services into base Service
    public class CountriesService : ICountriesService
    {
        private readonly IDbRepository<Country> countries;
        private readonly IIdentifierProvider identifierProvider;
        private readonly IDeletableEntityRepository<Country> deleteableRepo;

        public CountriesService(IDbRepository<Country> countries, IIdentifierProvider identifierProvider, IDeletableEntityRepository<Country> deleteableRepo)
        {
            this.countries = countries;
            this.identifierProvider = identifierProvider;
            this.deleteableRepo = deleteableRepo;
        }

        public IQueryable<Country> GetAll()
        {
            return this.countries.All();
        }

        public Country GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var country = this.countries.GetById(intId);

            return country;
        }

        public Country GetByIntId(int id)
        {
            var country = this.countries.GetById(id);

            return country;
        }

        public int AdminCreate(Country entity)
        {
            this.deleteableRepo.Add(entity);
            this.deleteableRepo.SaveChanges();
            return entity.Id;
        }

        public int AdminUpdate(Country entity)
        {
            this.deleteableRepo.Update(entity);
            this.deleteableRepo.SaveChanges();
            return entity.Id;
        }

        public void AdminDestroy(int id)
        {
            this.deleteableRepo.Delete(id);
            this.deleteableRepo.SaveChanges();
        }

        public void AdminDispose()
        {
            this.deleteableRepo.Dispose();
        }
    }
}

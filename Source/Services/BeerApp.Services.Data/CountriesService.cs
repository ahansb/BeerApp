namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Common;
    using BeerApp.Data.Models;
    using Web;

    // TODO: Extract from services into base Service
    public class CountriesService : ICountriesService
    {
        private readonly IDbRepository<Country> countries;
        private readonly IIdentifierProvider identifierProvider;

        public CountriesService(IDbRepository<Country> countries, IIdentifierProvider identifierProvider)
        {
            this.countries = countries;
            this.identifierProvider = identifierProvider;
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
    }
}

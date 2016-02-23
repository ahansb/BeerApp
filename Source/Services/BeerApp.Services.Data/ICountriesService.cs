namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Models;

    public interface ICountriesService
    {
        IQueryable<Country> GetAll();

        Country GetById(string id);

        Country GetByIntId(int id);

        int AdminCreate(Country entity);

        int AdminUpdate(Country entity);

        void AdminDestroy(int id);

        void AdminDispose();

    }
}

namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Models;

    public interface ICountriesService
    {
        IQueryable<Country> GetAll();

        Country GetById(string id);
    }
}

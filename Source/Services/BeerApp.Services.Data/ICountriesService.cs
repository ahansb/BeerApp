namespace BeerApp.Services.Data
{
    using BeerApp.Data.Models;

    public interface ICountriesService
    {
        Country GetById(string id);
    }
}

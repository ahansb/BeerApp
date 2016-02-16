namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Models;

    public interface IPlacesService
    {
        IQueryable<Place> GetAll();

        Place GetById(string id);

        int Add(Place place);
    }
}

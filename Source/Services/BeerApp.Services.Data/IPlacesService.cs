namespace BeerApp.Services.Data
{
    using BeerApp.Data.Models;

    public interface IPlacesService
    {
        Place GetById(string id);

        int Add(Place place);
    }
}

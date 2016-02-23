namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Models;

    public interface IPlacesService
    {
        IQueryable<Place> GetAll();

        Place GetById(string id);

        Place GetByIntId(int id);

        int Add(Place place);

        int AdminCreate(Place entity);

        int AdminUpdate(Place entity);

        void AdminDestroy(int id);

        void AdminDispose();

    }
}

namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Models;

    public interface IBeersService
    {
        IQueryable<Beer> GetAll();

        Beer GetById(string id);

        Beer GetByIntId(int id);

        int Add(Beer beer);

        int AdminCreate(Beer entity);

        int AdminUpdate(Beer entity);

        void AdminDestroy(int id);

        void AdminDispose();
    }
}

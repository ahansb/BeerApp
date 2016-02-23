namespace BeerApp.Services.Data
{
    using System.Linq;

    using BeerApp.Data.Models;

    public interface IBeerTypesService
    {
        IQueryable<BeerType> GetAll();

        BeerType GetById(string id);

        BeerType GetByIntId(int id);

        IQueryable<BeerType> GetRandom(int count);

        int AdminCreate(BeerType entity);

        int AdminUpdate(BeerType entity);

        void AdminDestroy(int id);

        void AdminDispose();
    }
}

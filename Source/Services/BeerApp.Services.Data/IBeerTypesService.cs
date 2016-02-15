namespace BeerApp.Services.Data
{
    using System.Linq;

    using BeerApp.Data.Models;

    public interface IBeerTypesService
    {
        IQueryable<BeerType> GetAll();

        BeerType GetById(string id);

        IQueryable<BeerType> GetRandom(int count);
    }
}

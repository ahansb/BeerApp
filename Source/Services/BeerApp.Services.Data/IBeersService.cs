namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Models;

    public interface IBeersService
    {
        IQueryable<Beer> GetAll();

        Beer GetById(string id);
    }
}

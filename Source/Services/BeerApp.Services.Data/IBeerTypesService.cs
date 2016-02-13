

namespace BeerApp.Services.Data
{
    using System.Linq;

    using BeerApp.Data.Models;

    public interface IBeerTypesService
    {
        IQueryable<BeerType> GetAll();
        
    }
}

namespace BeerApp.Services.Data
{
    using BeerApp.Data.Models;

    public interface IBeersService
    {
        Beer GetById(string id);
    }
}

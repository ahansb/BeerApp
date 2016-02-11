namespace BeerApp.Services.Data
{
    using System.Linq;

    using BeerApp.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}

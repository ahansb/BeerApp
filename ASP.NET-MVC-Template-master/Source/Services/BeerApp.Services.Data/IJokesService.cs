namespace BeerApp.Services.Data
{
    using System.Linq;

    using BeerApp.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}

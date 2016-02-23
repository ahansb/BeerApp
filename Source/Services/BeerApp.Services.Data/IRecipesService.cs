namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Models;

    public interface IRecipesService
    {
        IQueryable<Recipe> GetAll();

        Recipe GetById(string id);

        int Add(Recipe beer);

        Recipe GetByIntId(int id);

        int AdminCreate(Recipe entity);

        int AdminUpdate(Recipe entity);

        void AdminDestroy(int id);

        void AdminDispose();
    }
}

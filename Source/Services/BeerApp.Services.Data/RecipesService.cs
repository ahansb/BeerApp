namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Common.Repositories.Contracts;
    using BeerApp.Data.Models;
    using Web;

    public class RecipesService : IRecipesService
    {
        private readonly IDbRepository<Recipe> recipes;
        private readonly IIdentifierProvider identifierProvider;
        private readonly IDeletableEntityRepository<Recipe> deleteableRepo;

        public RecipesService(IDbRepository<Recipe> recipes, IIdentifierProvider identifierProvider, IDeletableEntityRepository<Recipe> deleteableRepo)
        {
            this.recipes = recipes;
            this.identifierProvider = identifierProvider;
            this.deleteableRepo = deleteableRepo;
        }

        public int Add(Recipe recipe)
        {
            this.recipes.Add(recipe);
            this.recipes.Save();
            return recipe.Id;
        }

        public IQueryable<Recipe> GetAll()
        {
            return this.recipes.All();
        }

        public Recipe GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var recipe = this.recipes.GetById(intId);

            return recipe;
        }

        public Recipe GetByIntId(int id)
        {
            var country = this.recipes.GetById(id);

            return country;
        }

        public int AdminCreate(Recipe entity)
        {
            this.deleteableRepo.Add(entity);
            this.deleteableRepo.SaveChanges();
            return entity.Id;
        }

        public int AdminUpdate(Recipe entity)
        {
            this.deleteableRepo.Update(entity);
            this.deleteableRepo.SaveChanges();
            return entity.Id;
        }

        public void AdminDestroy(int id)
        {
            this.deleteableRepo.Delete(id);
            this.deleteableRepo.SaveChanges();
        }

        public void AdminDispose()
        {
            this.deleteableRepo.Dispose();
        }
    }
}

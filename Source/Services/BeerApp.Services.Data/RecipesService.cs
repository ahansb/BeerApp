namespace BeerApp.Services.Data
{
    using System;
    using System.Linq;
    using BeerApp.Data.Common;
    using BeerApp.Data.Models;
    using Web;

    public class RecipesService : IRecipesService
    {
        private readonly IDbRepository<Recipe> recipes;
        private readonly IIdentifierProvider identifierProvider;

        public RecipesService(IDbRepository<Recipe> recipes, IIdentifierProvider identifierProvider)
        {
            this.recipes = recipes;
            this.identifierProvider = identifierProvider;
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
    }
}

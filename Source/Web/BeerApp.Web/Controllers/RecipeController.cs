namespace BeerApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data;
    using Services.Web;
    using ViewModels.Recipe;
    using ViewModels.BeerType;
    public class RecipeController : BaseController
    {
        private readonly IRecipesService recipes;
        private readonly IBeerTypesService beerTypes;
        private readonly IIdentifierProvider identifier;

        public RecipeController(IRecipesService recipes, IIdentifierProvider identifier, IBeerTypesService beerTypes)
        {
            this.recipes = recipes;
            this.beerTypes = beerTypes;
            this.identifier = identifier;
        }

        [HttpGet]
        public ActionResult All()
        {
            var recipes = this.recipes.GetAll().OrderBy(r => r.BeerType.Name).ToList();

            ICollection<RecipeResponseViewModel> recipesView = this.Mapper.Map<ICollection<RecipeResponseViewModel>>(recipes);

            return this.View(recipesView);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var recipe = this.recipes.GetById(id);

            RecipeResponseViewModel recipeView = this.Mapper.Map<RecipeResponseViewModel>(recipe);

            return this.View(recipeView);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var types = this.beerTypes.GetAll().OrderBy(x => x.Name).ToArray();
            var viewTypes = this.Mapper.Map<IEnumerable<SimpleBeerTypeResponseViewModel>>(types);

            var model = new RecipeRequestViewModel();

            model.BeerTypes = viewTypes;

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RecipeRequestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var recipe = this.Mapper.Map<Recipe>(model);
            var recipeId = this.recipes.Add(recipe);

            return this.RedirectToAction("Details", new { id = this.identifier.EncodeId(recipeId) });
        }
    }
}
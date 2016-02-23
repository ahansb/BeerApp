namespace BeerApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data;
    using Services.Web;
    using ViewModels.BeerType;
    using ViewModels.Recipe;

    [Authorize]
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
            var types = this.beerTypes.GetAll().Where(x => x.Recipes.Any()).OrderBy(x => x.Name).ToList();
            var typesView = this.Mapper.Map<ICollection<BeerTypeResponseViewModel>>(types);

            return this.View(typesView);
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
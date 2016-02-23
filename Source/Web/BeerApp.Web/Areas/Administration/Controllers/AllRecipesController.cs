namespace BeerApp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using ViewModels.Recipe;
    using Web.ViewModels.BeerType;

    public class AllRecipesController : BaseAdminController
    {
        private readonly IRecipesService recipes;
        private readonly IBeerTypesService beerTypes;

        public AllRecipesController(IRecipesService recipes, IBeerTypesService beerTypes)
        {
            this.recipes = recipes;
            this.beerTypes = beerTypes;
        }

        public ActionResult Index()
        {
            var types = this.beerTypes.GetAll().OrderBy(t => t.Name);

            var typesView = this.Mapper.Map<IEnumerable<SimpleBeerTypeResponseViewModel>>(types);

            this.ViewData["types"] = typesView;

            return this.View();
        }

        public ActionResult Recipes_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.recipes.GetAll().To<AdminRecipeViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Recipes_Create([DataSourceRequest]DataSourceRequest request, AdminRecipeRequestViewModel recipe)
        {
            var newId = 0;

            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Recipe>(recipe);

                newId = this.recipes.AdminCreate(entity);
            }

            var newRecipe = this.recipes.GetByIntId(newId);
            var recipeToDisplay = this.Mapper.Map<AdminRecipeViewModel>(newRecipe);

            return this.Json(new[] { recipeToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Recipes_Update([DataSourceRequest]DataSourceRequest request, AdminUpdateRecipeRequestViewModel recipe)
        {
            var id = 0;
            if (this.ModelState.IsValid)
            {
                var entity = this.recipes.GetByIntId(recipe.Id);
                entity.BeerTypeId = recipe.BeerTypeId;
                entity.Title = recipe.Title;
                entity.Content = recipe.Content;
                id = this.recipes.AdminUpdate(entity);
            }

            var newRecipe = this.recipes.GetByIntId(id);
            var beerToDisplay = this.Mapper.Map<AdminRecipeViewModel>(newRecipe);
            return this.Json(new[] { beerToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Recipes_Destroy([DataSourceRequest]DataSourceRequest request, AdminUpdateRecipeRequestViewModel recipe)
        {
            this.recipes.AdminDestroy(recipe.Id);

            return this.Json(new[] { recipe }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            this.recipes.AdminDispose();
            base.Dispose(disposing);
        }
    }
}

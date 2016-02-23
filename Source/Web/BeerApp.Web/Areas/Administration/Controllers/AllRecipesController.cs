namespace BeerApp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using ViewModels.Recipe;
    using Services.Data;
    using Web.ViewModels.BeerType;
    using Infrastructure.Mapping;
    using Data.Models;
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
        public ActionResult Recipes_Create([DataSourceRequest]DataSourceRequest request, AdminRecipeRequestViewModel beer)
        {
            var newId = 0;

            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Recipe>(beer);

                newId = this.recipes.AdminCreate(entity);
            }

            var newRecipe = this.recipes.GetByIntId(newId);
            var beerToDisplay = this.Mapper.Map<AdminRecipeViewModel>(newRecipe);

            return this.Json(new[] { beerToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Recipes_Update([DataSourceRequest]DataSourceRequest request, AdminUpdateRecipeRequestViewModel beer)
        {
            var id = 0;
            if (this.ModelState.IsValid)
            {
                var entity = this.recipes.GetByIntId(beer.Id);
                entity.Name = beer.Name;
                entity.RecipeTypeId = beer.RecipeTypeId;
                entity.CountryId = beer.CountryId;
                entity.Description = beer.Description;
                entity.ProducedSince = beer.ProducedSince;
                entity.AlcoholContaining = beer.AlcoholContaining;
                entity.PhotoUrl = beer.PhotoUrl;
                id = this.recipes.AdminUpdate(entity);
            }

            var newRecipe = this.recipes.GetByIntId(id);
            var beerToDisplay = this.Mapper.Map<AdminRecipeViewModel>(newRecipe);
            return this.Json(new[] { beerToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Recipes_Destroy([DataSourceRequest]DataSourceRequest request, AdminUpdateRecipeRequestViewModel beer)
        {
            this.recipes.AdminDestroy(beer.Id);

            return this.Json(new[] { beer }.ToDataSourceResult(request, this.ModelState));
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

namespace BeerApp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using ViewModels.BeerType;

    [Authorize(Roles = "Admin")]
    public class AllBeerTypesController : BaseAdminController
    {
        private readonly IBeerTypesService beerTypes;

        public AllBeerTypesController(IBeerTypesService beerTypes)
        {
            this.beerTypes = beerTypes;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult BeerTypes_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.beerTypes.GetAll().To<AdminBeerTypeViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BeerTypes_Create([DataSourceRequest]DataSourceRequest request, AdminBeerTypeRequestViewModel beerType)
        {
            var newId = 0;

            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<BeerType>(beerType);

                newId = this.beerTypes.AdminCreate(entity);
            }

            var newBeerType = this.beerTypes.GetByIntId(newId);
            var beerTypeToDisplay = this.Mapper.Map<AdminBeerTypeViewModel>(newBeerType);

            return this.Json(new[] { beerTypeToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BeerTypes_Update([DataSourceRequest]DataSourceRequest request, AdminUpdateBeerTypeRequestViewModel beerType)
        {
            var id = 0;
            if (this.ModelState.IsValid)
            {
                var entity = this.beerTypes.GetByIntId(beerType.Id);
                entity.Name = beerType.Name;
                id = this.beerTypes.AdminUpdate(entity);
            }

            var newBeer = this.beerTypes.GetByIntId(id);
            var beerToDisplay = this.Mapper.Map<AdminBeerTypeViewModel>(newBeer);
            return this.Json(new[] { beerToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BeerTypes_Destroy([DataSourceRequest]DataSourceRequest request, AdminUpdateBeerTypeRequestViewModel beerType)
        {
            this.beerTypes.AdminDestroy(beerType.Id);

            return this.Json(new[] { beerType }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            this.beerTypes.AdminDispose();
            base.Dispose(disposing);
        }

    }
}
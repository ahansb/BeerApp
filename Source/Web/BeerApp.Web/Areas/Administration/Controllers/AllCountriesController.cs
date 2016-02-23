namespace BeerApp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using ViewModels.Country;

    public class AllCountriesController : BaseAdminController
    {
        private readonly ICountriesService countries;

        public AllCountriesController(ICountriesService countries)
        {
            this.countries = countries;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Countries_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.countries.GetAll().To<AdminCountryViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Countries_Create([DataSourceRequest]DataSourceRequest request, AdminCountryRequestViewModel country)
        {
            var newId = 0;

            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Country>(country);

                newId = this.countries.AdminCreate(entity);
            }

            var newBeerType = this.countries.GetByIntId(newId);
            var beerTypeToDisplay = this.Mapper.Map<AdminCountryViewModel>(newBeerType);

            return this.Json(new[] { beerTypeToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Countries_Update([DataSourceRequest]DataSourceRequest request, AdminUpdateCountryRequestViewModel country)
        {
            var id = 0;
            if (this.ModelState.IsValid)
            {
                var entity = this.countries.GetByIntId(country.Id);
                entity.Name = country.Name;
                id = this.countries.AdminUpdate(entity);
            }

            var newBeer = this.countries.GetByIntId(id);
            var beerToDisplay = this.Mapper.Map<AdminCountryViewModel>(newBeer);
            return this.Json(new[] { beerToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Countries_Destroy([DataSourceRequest]DataSourceRequest request, AdminUpdateCountryRequestViewModel country)
        {
            // TODO: Fix
            this.countries.AdminDestroy(country.Id);

            return this.Json(new[] { country }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            this.countries.AdminDispose();
            base.Dispose(disposing);
        }
    }
}
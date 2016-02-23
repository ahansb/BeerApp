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
    using ViewModels.Beer;
    using Web.ViewModels.BeerType;
    using Web.ViewModels.Country;

    [Authorize(Roles = "Admin")]
    public class AllBeersController : BaseAdminController
    {
        private readonly IBeersService beers;
        private readonly IBeerTypesService beerTypes;
        private readonly ICountriesService countries;

        public AllBeersController(IBeersService beers, IBeerTypesService beerTypes, ICountriesService countries)
        {
            this.beers = beers;
            this.beerTypes = beerTypes;
            this.countries = countries;
        }

        public ActionResult Index()
        {
            var types = this.beerTypes.GetAll().OrderBy(t => t.Name);
            var databaseCountries = this.countries.GetAll().OrderBy(c => c.Name);

            var typesView = this.Mapper.Map<IEnumerable<SimpleBeerTypeResponseViewModel>>(types);
            var countriesView = this.Mapper.Map<IEnumerable<SimpleCountryResponseViewModel>>(databaseCountries);

            this.ViewData["types"] = typesView;
            this.ViewData["countries"] = countriesView;

            return this.View();
        }

        public ActionResult Beers_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.beers.GetAll().To<AdminBeerViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Beers_Create([DataSourceRequest]DataSourceRequest request, AdminBeerRequestViewModel beer)
        {
            var newId = 0;

            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Beer>(beer);

                newId = this.beers.AdminCreate(entity);
            }

            var newBeer = this.beers.GetByIntId(newId);
            var beerToDisplay = this.Mapper.Map<AdminBeerViewModel>(newBeer);

            return this.Json(new[] { beerToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Beers_Update([DataSourceRequest]DataSourceRequest request, AdminUpdateBeerRequestViewModel beer)
        {
            var id = 0;
            if (this.ModelState.IsValid)
            {
                var entity = this.beers.GetByIntId(beer.Id);
                entity.Name = beer.Name;
                entity.BeerTypeId = beer.BeerTypeId;
                entity.CountryId = beer.CountryId;
                entity.Description = beer.Description;
                entity.ProducedSince = beer.ProducedSince;
                entity.AlcoholContaining = beer.AlcoholContaining;
                entity.PhotoUrl = beer.PhotoUrl;
                id = this.beers.AdminUpdate(entity);
            }

            var newBeer = this.beers.GetByIntId(id);
            var beerToDisplay = this.Mapper.Map<AdminBeerViewModel>(newBeer);
            return this.Json(new[] { beerToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Beers_Destroy([DataSourceRequest]DataSourceRequest request, AdminUpdateBeerRequestViewModel beer)
        {
            this.beers.AdminDestroy(beer.Id);

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
            this.beers.AdminDispose();
            base.Dispose(disposing);
        }
    }
}

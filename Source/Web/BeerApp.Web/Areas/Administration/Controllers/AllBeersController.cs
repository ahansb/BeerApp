namespace BeerApp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using ViewModels.Beer;
    using System.Collections.Generic;
    using Web.ViewModels.BeerType;
    using Web.ViewModels.Country;
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
            var dbCountries = this.countries.GetAll().OrderBy(c => c.Name);

            var typesView = this.Mapper.Map<IEnumerable<SimpleBeerTypeResponseViewModel>>(types);
            var countriesView = this.Mapper.Map<IEnumerable<SimpleCountryResponseViewModel>>(dbCountries);

            ViewData["types"] = typesView;
            ViewData["countries"] = countriesView;

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
        public ActionResult Beers_Update([DataSourceRequest]DataSourceRequest request, AdminBeerRequestViewModel beer)
        {
            int id = 0;
            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Beer>(beer);
                id = this.beers.AdminUpdate(entity);
            }

            var newBeer = this.beers.GetByIntId(id);

            return this.Json(new[] { newBeer }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Beers_Destroy([DataSourceRequest]DataSourceRequest request, Beer beer)
        {
            this.beers.AdminDestroy(beer.Id);
            //db.Beers.Attach(entity);
            //db.Beers.Remove(entity);
            //db.SaveChanges();

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

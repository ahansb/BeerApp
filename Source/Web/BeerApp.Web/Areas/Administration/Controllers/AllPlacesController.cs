namespace BeerApp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using ViewModels.Place;
    using Web.ViewModels.Country;
    using Microsoft.AspNet.Identity;

    [Authorize(Roles = "Admin")]
    public class AllPlacesController : BaseAdminController
    {
        private readonly IPlacesService places;
        private readonly ICountriesService countries;

        public AllPlacesController(IPlacesService places, ICountriesService countries)
        {
            this.places = places;
            this.countries = countries;
        }

        public ActionResult Index()
        {
            var databaseCountries = this.countries.GetAll().OrderBy(c => c.Name);
            var countriesView = this.Mapper.Map<IEnumerable<SimpleCountryResponseViewModel>>(databaseCountries);

            this.ViewData["countries"] = countriesView;
            this.ViewData["defaultValue"] = countriesView.FirstOrDefault();

            return this.View();
        }

        public ActionResult Places_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.places.GetAll().To<AdminPlaceViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        // TODO: CountryId does not work
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Places_Create([DataSourceRequest]DataSourceRequest request, AdminPlaceRequestViewModel place)
        {
            var newId = 0;
        
            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Place>(place);

                newId = this.places.AdminCreate(entity);
            }

            var newBeer = this.places.GetByIntId(newId);
            var beerToDisplay = this.Mapper.Map<AdminPlaceViewModel>(newBeer);

            return this.Json(new[] { beerToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Places_Update([DataSourceRequest]DataSourceRequest request, AdminUpdatePlaceRequestViewModel place)
        {
            var id = 0;
            if (this.ModelState.IsValid)
            {
                var entity = this.places.GetByIntId(place.Id);
                entity.Name = place.Name;
                entity.Type = place.Type;
                entity.CountryId = place.CountryId;
                entity.City = place.City;
                entity.Address = place.Address;
                entity.Phone = place.Phone;
                entity.PhotoUrl = place.PhotoUrl;
                id = this.places.AdminUpdate(entity);
            }

            var newBeer = this.places.GetByIntId(id);
            var beerToDisplay = this.Mapper.Map<AdminPlaceViewModel>(newBeer);
            return this.Json(new[] { beerToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Places_Destroy([DataSourceRequest]DataSourceRequest request, AdminUpdatePlaceRequestViewModel place)
        {
            this.places.AdminDestroy(place.Id);

            return this.Json(new[] { place }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            this.places.AdminDispose();
            base.Dispose(disposing);
        }
    }
}

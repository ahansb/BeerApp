namespace BeerApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data;
    using Services.Web;
    using ViewModels.Country;
    using ViewModels.Place;

    [Authorize]
    public class PlaceController : BaseController
    {
        private readonly IPlacesService places;
        private readonly ICountriesService countries;
        private readonly IIdentifierProvider identifier;

        public PlaceController(IPlacesService places, IIdentifierProvider identifier, ICountriesService countries)
        {
            this.places = places;
            this.countries = countries;
            this.identifier = identifier;
        }

        [HttpGet]
        public ActionResult All()
        {
            var places = this.places.GetAll().OrderBy(p => p.Country.Name).ToList();

            var placesView = this.Mapper.Map<ICollection<PlaceResponseViewModel>>(places);

            return this.View(placesView);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var place = this.places.GetById(id);

            var placeView = this.Mapper.Map<PlaceResponseViewModel>(place);

            return this.View(placeView);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var placeCountries = this.countries.GetAll().OrderBy(x => x.Name).ToArray();
            var viewCountries = this.Mapper.Map<IEnumerable<SimpleCountryResponseViewModel>>(placeCountries);
            var model = new PlaceRequestViewModel();
            model.Countries = viewCountries;

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PlaceRequestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var place = this.Mapper.Map<Place>(model);
            var placeId = this.places.Add(place);

            return this.RedirectToAction("Details", new { id = this.identifier.EncodeId(placeId) });
        }
    }
}
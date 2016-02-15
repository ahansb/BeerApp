namespace BeerApp.Web.Controllers
{
    using Data.Models;
    using Services.Data;
    using Services.Web;
    using System.Web.Mvc;
    using ViewModels.Place;

    [Authorize]
    public class PlaceController : BaseController
    {
        private readonly IPlacesService places;
        private readonly IIdentifierProvider identifier;

        public PlaceController(IPlacesService places, IIdentifierProvider identifier)
        {
            this.places = places;
            this.identifier = identifier;
        }

        //[HttpGet]
        //public ActionResult Details(string id)
        //{
        //    var place = this.places.GetById(id);

        //    BeerResponseViewModel beerView = this.Mapper.Map<BeerResponseViewModel>(beer);
        //    BeerTypeResponseViewModel beerTypeView = this.Mapper.Map<BeerTypeResponseViewModel>(beer.Type);
        //    CountryResponseViewModel countryView = this.Mapper.Map<CountryResponseViewModel>(beer.Country);

        //    var viewModel = new BeerDetailsResponseViewModel
        //    {
        //        Beer = beerView,
        //        BeerType = beerTypeView,
        //        Country = countryView
        //    };

        //    return this.View(viewModel);
        //}

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PlaceRequestViewModel model)
        {
            if (!this.ModelState.IsValid || model == null)
            {
                this.ModelState.AddModelError("", "Please, fill the form correctly!");
                return this.View(model);
            }

            var place = this.Mapper.Map<Place>(model);
            var placeId = this.places.Add(place);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
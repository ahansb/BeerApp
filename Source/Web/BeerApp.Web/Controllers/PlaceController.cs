namespace BeerApp.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data;
    using Services.Web;
    using ViewModels.Place;
    using System.Linq;
    using System.Collections.Generic;
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

        [HttpGet]
        public ActionResult All()
        {
            var places = this.places.GetAll().OrderBy(p => p.Country.Name).ToList();

            ICollection<PlaceResponseViewModel> placesView = this.Mapper.Map<ICollection<PlaceResponseViewModel>>(places);

            return this.View(places);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var place = this.places.GetById(id);

            PlaceResponseViewModel placeView = this.Mapper.Map<PlaceResponseViewModel>(place);

            return this.View(placeView);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
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
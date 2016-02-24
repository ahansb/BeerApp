namespace BeerApp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data;
    using Services.Web;
    using ViewModels.Place;
    using ViewModels.Places;

    public class PlacesController : BaseController
    {
        private const int ItemsPerPage = 4;
        private readonly IPlacesService places;
        private readonly IIdentifierProvider identifier;

        public PlacesController(IPlacesService places, IIdentifierProvider identifier)
        {
            this.places = places;
            this.identifier = identifier;
        }

        [HttpGet]
        public ActionResult All(string id)
        {
            int page;
            if (id == string.Empty || id == null)
            {
                page = 1;
            }
            else
            {
                page = this.identifier.DecodeId(id);
            }

            var allItemsCount = this.places.GetAll().Count();
            var totalPages = (int) Math.Ceiling(allItemsCount / (decimal) ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var placesForVisualizing = this.places.GetAll()
                .OrderBy(x => x.Name)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage)
                .ToList();
            var placesViewModel = this.Mapper.Map<ICollection<PlaceResponseViewModel>>(placesForVisualizing);

            var viewModel = new PlacesResponseViewModel(this.identifier)
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Places = placesViewModel
            };

            return this.View(viewModel);
        }
    }
}

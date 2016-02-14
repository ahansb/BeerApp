namespace BeerApp.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Data;
    using ViewModels.BeerType;
    using System.Collections.Generic;
    using ViewModels.Beer;
    [Authorize]
    public class BeerTypeController : BaseController
    {
        private readonly IBeerTypesService beerTypes;

        public BeerTypeController(IBeerTypesService beerTypes)
        {
            this.beerTypes = beerTypes;
        }

        // GET: BeerType
        public ActionResult BeerTypeDetails(string id)
        {
            var beerType = this.beerTypes.GetById(id);

            BeerTypeResponseViewModel beerTypeView = this.Mapper.Map<BeerTypeResponseViewModel>(beerType);
            ICollection<SimpleBeerResponseViewModel> beers = this.Mapper.Map<ICollection<SimpleBeerResponseViewModel>>(beerType.Beers);

            var viewModel = new BeerTypeDetailsResponseViewModel
            {
                BeerType = beerTypeView,
                Beers = beers

            };

            return this.View(viewModel);
        }
    }
}
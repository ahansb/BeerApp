namespace BeerApp.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Data;
    using ViewModels.Beer;
    using ViewModels.BeerType;
    using ViewModels.Country;
    using Web.Infrastructure;

    [Authorize]
    public class BeerController : BaseController
    {
        private readonly IBeersService beers;

        public BeerController(IBeersService beers)
        {
            this.beers = beers;
        }

        // TODO: BeerResponseModel exclude type coutry and collections
        // GET: Beer
        public ActionResult Details(string id)
        {
            var beer = this.beers.GetById(id);
            
            BeerResponseViewModel beerView = this.Mapper.Map<BeerResponseViewModel>(beer);
            BeerTypeResponseViewModel beerTypeView = this.Mapper.Map<BeerTypeResponseViewModel>(beer.Type);
            CountryResponseViewModel countryView = this.Mapper.Map<CountryResponseViewModel>(beer.Country);

            var viewModel = new BeerDetailsResponseViewModel
            {
                Beer = beerView,
                BeerType = beerTypeView,
                Country = countryView
            };

            return this.View(viewModel);
        }
    }
}

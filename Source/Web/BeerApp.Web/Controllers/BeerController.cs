namespace BeerApp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data;
    using ViewModels.Beer;
    using ViewModels.BeerType;
    using ViewModels.Country;

    [Authorize]
    public class BeerController : BaseController
    {
        private readonly IBeersService beers;

        public BeerController(IBeersService beers)
        {
            this.beers = beers;
        }

        public ActionResult All()
        {
            var beers = this.beers.GetAll().OrderBy(b => b.Name);
            var allViewModel = new AllBeersResponseViewModel();
            foreach (var beer in beers)
            {
                BeerResponseViewModel beerView = this.Mapper.Map<BeerResponseViewModel>(beer);
                BeerTypeResponseViewModel beerTypeView = this.Mapper.Map<BeerTypeResponseViewModel>(beer.Type);
                CountryResponseViewModel countryView = this.Mapper.Map<CountryResponseViewModel>(beer.Country);

                var viewModel = new BeerDetailsResponseViewModel
                {
                    Beer = beerView,
                    BeerType = beerTypeView,
                    Country = countryView
                };

                allViewModel.Beers.Add(viewModel);
            }

            return this.View(allViewModel);
        }

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

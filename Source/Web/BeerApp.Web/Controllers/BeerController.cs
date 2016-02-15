namespace BeerApp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data;
    using ViewModels.Beer;
    using ViewModels.BeerType;
    using ViewModels.Country;
    using Data.Models;
    using Services.Web;
    [Authorize]
    public class BeerController : BaseController
    {
        private readonly IBeersService beers;
        private readonly IIdentifierProvider identifier;

        public BeerController(IBeersService beers, IIdentifierProvider identifier)
        {
            this.beers = beers;
            this.identifier = identifier;
        }

        [HttpGet]
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

        [HttpGet]
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

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BeerRequestViewModel model)
        {

            if (!this.ModelState.IsValid || model == null)
            {
                this.ModelState.AddModelError("", "Please, fill the form correctly!");
                return this.View(model);
            }

            var beer = this.Mapper.Map<Beer>(model);
            var beerId = this.beers.Add(beer);

            return this.RedirectToAction("Details", new { id = this.identifier.EncodeId(beerId) });
        }
    }
}

namespace BeerApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data;
    using Services.Web;
    using ViewModels.Beer;
    using ViewModels.BeerType;
    using ViewModels.Country;
    [Authorize]
    public class BeerController : BaseController
    {
        private readonly IBeersService beers;
        private readonly ICountriesService countries;
        private readonly IBeerTypesService beerTypes;
        private readonly IIdentifierProvider identifier;

        public BeerController(IBeersService beers, IIdentifierProvider identifier, ICountriesService countries, IBeerTypesService beerTypes)
        {
            this.beers = beers;
            this.countries = countries;
            this.beerTypes = beerTypes;
            this.identifier = identifier;
        }

        [HttpGet]
        public ActionResult All()
        {
            var beers = this.beers.GetAll().OrderBy(b => b.Name).ToList();

            var viewModel = this.Mapper.Map<ICollection<BeerResponseViewModel>>(beers);

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var beer = this.beers.GetById(id);

            BeerResponseViewModel viewModel = this.Mapper.Map<BeerResponseViewModel>(beer);

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var types = this.beerTypes.GetAll().OrderBy(x => x.Name).ToArray();
            var beerCountries = this.countries.GetAll().OrderBy(x => x.Name).ToArray();

            var viewTypes = this.Mapper.Map<IEnumerable<SimpleBeerTypeResponseViewModel>>(types);
            var viewCountries = this.Mapper.Map<IEnumerable<SimpleCountryResponseViewModel>>(beerCountries);

            var model = new BeerRequestViewModel();

            model.BeerTypes = viewTypes;
            model.Countries = viewCountries;

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BeerRequestViewModel model)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var beer = this.Mapper.Map<Beer>(model);
            var beerId = this.beers.Add(beer);

            return this.RedirectToAction("Details", new { id = this.identifier.EncodeId(beerId) });
        }
    }
}

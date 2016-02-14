namespace BeerApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Services.Data;
    using ViewModels.Beer;
    using ViewModels.BeerType;
    using Web.Infrastructure.Mapping;
    using System.Linq;
    using System.Collections;
    [Authorize]
    public class BeerTypeController : BaseController
    {
        private readonly IBeerTypesService beerTypes;

        public BeerTypeController(IBeerTypesService beerTypes)
        {
            this.beerTypes = beerTypes;
        }

        [HttpGet]
        public ActionResult All()
        {
            var beerTypes = this.beerTypes.GetAll();
            var allViewModel = new AllBeerTypesResponseViewModel();
            foreach (var beerType in beerTypes)
            {
                BeerTypeResponseViewModel beerTypeView = this.Mapper.Map<BeerTypeResponseViewModel>(beerType);
                ICollection<SimpleBeerResponseViewModel> beers = this.Mapper.Map<ICollection<SimpleBeerResponseViewModel>>(beerType.Beers);

                var viewModel = new BeerTypeDetailsResponseViewModel
                {
                    BeerType = beerTypeView,
                    Beers = beers

                };

                allViewModel.Types.Add(viewModel);
            }

            return this.View(allViewModel);
        }

        // GET: BeerType
        public ActionResult Details(string id)
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
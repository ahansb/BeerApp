namespace BeerApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.BeerType;

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
            var beerTypesView = this.Cache.Get(
                "allBeerTypes",
                () => this.Mapper.Map<ICollection<SimpleBeerTypeResponseViewModel>>(this.beerTypes.GetAll().OrderBy(bt => bt.Name)).ToList(),
                3 * 60 * 60);

            return this.View(beerTypesView);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var beerType = this.beerTypes.GetById(id);

            BeerTypeResponseViewModel viewModel = this.Mapper.Map<BeerTypeResponseViewModel>(beerType);

            return this.View(viewModel);
        }
    }
}
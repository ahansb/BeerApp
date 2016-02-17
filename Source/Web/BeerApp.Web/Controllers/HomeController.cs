namespace BeerApp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.BeerType;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IBeerTypesService beerTypes;

        public HomeController(
            IBeerTypesService beerTypes)
        {
            this.beerTypes = beerTypes;
        }

        // TODO: Refactor viewModel
        public ActionResult Index()
        {
            var beerTypes = this.Cache.Get(
                "beerTypes",
                () => this.beerTypes.GetRandom(3).To<BeerTypeResponseViewModel>().ToList(),
                5 * 60);

            var viewModel = new IndexResponseViewModel
            {
                BeerTypes = beerTypes
            };

            return this.View(viewModel);
        }
    }
}

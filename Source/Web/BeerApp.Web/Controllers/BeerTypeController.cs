namespace BeerApp.Web.Controllers
{
    using System.Web.Mvc;
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

        // GET: BeerType
        public ActionResult BeerTypeDetails(string id)
        {
            var beerType = this.beerTypes.GetById(id);

            BeerTypeDetailsViewModel beerTypeView = this.Mapper.Map<BeerTypeDetailsViewModel>(beerType);

            return this.View(beerTypeView);
        }
    }
}
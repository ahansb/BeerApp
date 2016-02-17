namespace BeerApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data;
    using Services.Web;
    using ViewModels.Beer;

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
            return this.View();
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

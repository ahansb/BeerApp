namespace BeerApp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using Services.Web;
    using ViewModels.Beer;
    using ViewModels.Beers;

    [Authorize]
    public class BeersController : BaseController
    {
        private const int ItemsPerPage = 4;
        private readonly IBeersService beers;
        private readonly IIdentifierProvider identifier;

        public BeersController(IBeersService beers, IIdentifierProvider identifier)
        {
            this.beers = beers;
            this.identifier = identifier;
        }

        [HttpGet]
        public ActionResult All(string id)
        {
            int page;
            if (id == string.Empty || id == null)
            {
                page = 1;
            }
            else
            {
                page = this.identifier.DecodeId(id);
            }

            var allItemsCount = this.beers.GetAll().Count();
            var totalPages = (int) Math.Ceiling(allItemsCount / (decimal) ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var beersForVisualizing = this.beers.GetAll()
                .OrderBy(x => x.Name)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage)
                .ToList();
            var beersViewModel = this.Mapper.Map<ICollection<BeerResponseViewModel>>(beersForVisualizing);

            var viewModel = new BeersResponseViewModel(this.identifier)
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Beers = beersViewModel
            };

            // TODO:Cache 1:25
            return this.View(viewModel);
        }
    }
}
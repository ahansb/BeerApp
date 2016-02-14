namespace BeerApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Services.Data;
    using ViewModels.Beer;
    using ViewModels.Country;
    using System.Linq;
    using ViewModels.BeerType;
    [Authorize]
    public class CountryController : BaseController
    {
        private readonly ICountriesService countries;

        public CountryController(ICountriesService countries)
        {
            this.countries = countries;
        }

        // GET: Country
        public ActionResult Details(string id)
        {
            var country = this.countries.GetById(id);

            CountryResponseViewModel countryView = this.Mapper.Map<CountryResponseViewModel>(country);
            ICollection<SimpleBeerResponseViewModel> beersView = this.Mapper.Map<ICollection<SimpleBeerResponseViewModel>>(country.Beers);

            // TODO: Add Places
            var viewModel = new CountryDetailsResponseViewModel
            {
                Country = countryView,
                Beers = beersView
            };

            return this.View(viewModel);
        }
    }
}

namespace BeerApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data;
    using ViewModels.Beer;
    using ViewModels.Country;

    [Authorize]
    public class CountryController : BaseController
    {
        private readonly ICountriesService countries;

        public CountryController(ICountriesService countries)
        {
            this.countries = countries;
        }

        public ActionResult All()
        {
            var countries = this.countries.GetAll().OrderBy(c => c.Name);
            var allViewModel = new AllCountriesResponseViewModel();
            foreach (var country in countries)
            {
                CountryResponseViewModel countryView = this.Mapper.Map<CountryResponseViewModel>(country);
                ICollection<SimpleBeerResponseViewModel> beersView = this.Mapper.Map<ICollection<SimpleBeerResponseViewModel>>(country.Beers);

                // TODO: Add Places
                var viewModel = new CountryDetailsResponseViewModel
                {
                    Country = countryView,
                    Beers = beersView
                };

                allViewModel.Countries.Add(viewModel);
            }

            return this.View(allViewModel);
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

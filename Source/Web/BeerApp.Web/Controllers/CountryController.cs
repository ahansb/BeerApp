namespace BeerApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
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

        [HttpGet]
        public ActionResult All()
        {
            var countriesView = this.Cache.Get(
                   "countries",
                   () => this.Mapper.Map<ICollection<SimpleCountryResponseViewModel>>(this.countries.GetAll().OrderBy(c => c.Name)).ToList(),
                   3 * 60 * 60);
            //var countries = this.countries.GetAll().OrderBy(c => c.Name).ToList();

            //var viewModel = this.Mapper.Map<ICollection<SimpleCountryResponseViewModel>>(countries);

            //return this.View(viewModel);
            return this.View(countriesView);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var country = this.countries.GetById(id);

            var viewModel = this.Mapper.Map<CountryResponseViewModel>(country);

            return this.View(viewModel);
        }
    }
}

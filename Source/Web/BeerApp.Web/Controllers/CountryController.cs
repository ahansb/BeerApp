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

        [HttpGet]
        public ActionResult All()
        {
            var countries = this.countries.GetAll().OrderBy(c => c.Name).ToList();

            var viewModel = this.Mapper.Map<ICollection<SimpleCountryResponseViewModel>>(countries);

            return this.View(viewModel);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerApp.Web.ViewModels.Country
{
    public class AllCountriesResponseViewModel
    {
        public AllCountriesResponseViewModel()
        {
            this.Countries = new List<CountryDetailsResponseViewModel>();
        }

        public ICollection<CountryDetailsResponseViewModel> Countries { get; set; }
    }
}
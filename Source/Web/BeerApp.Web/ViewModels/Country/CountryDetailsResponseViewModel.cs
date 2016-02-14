namespace BeerApp.Web.ViewModels.Country
{
    using System.Collections.Generic;
    using Beer;
    using BeerType;

    public class CountryDetailsResponseViewModel
    {
        public CountryResponseViewModel Country { get; set; }

        public ICollection<SimpleBeerResponseViewModel> Beers { get; set; }

        // TODO: Add places
    }
}

namespace BeerApp.Web.ViewModels.BeerType
{
    using Beer;
    using System.Collections.Generic;

    public class BeerTypeDetailsResponseViewModel
    {
            public BeerTypeResponseViewModel BeerType { get; set; }

            public IEnumerable<SimpleBeerResponseViewModel> Beers { get; set; }
    }
}
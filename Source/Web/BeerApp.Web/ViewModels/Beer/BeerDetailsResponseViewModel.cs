namespace BeerApp.Web.ViewModels.Beer
{
    using BeerType;
    using Country;

    public class BeerDetailsResponseViewModel
    {
        public BeerResponseViewModel Beer { get; set; }

        public SimpleBeerTypeResponseViewModel BeerType { get; set; }

        public SimpleCountryResponseViewModel Country { get; set; }
    }
}

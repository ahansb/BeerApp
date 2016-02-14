namespace BeerApp.Web.ViewModels.Beer
{
    using BeerType;
    using Country;

    public class BeerDetailsResponseViewModel
    {
        public BeerResponseViewModel Beer { get; set; }

        public BeerTypeResponseViewModel BeerType { get; set; }

        public CountryResponseViewModel Country { get; set; }
    }
}

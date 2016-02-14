namespace BeerApp.Web.ViewModels.Beer
{
    using System.Collections.Generic;

    public class AllBeersResponseViewModel
    {
        public AllBeersResponseViewModel()
        {
            this.Beers = new List<BeerDetailsResponseViewModel>();
        }

        public ICollection<BeerDetailsResponseViewModel> Beers { get; set; }
    }
}
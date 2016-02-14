namespace BeerApp.Web.ViewModels.BeerType
{
    using System.Collections.Generic;

    public class AllBeerTypesResponseViewModel
    {
        public AllBeerTypesResponseViewModel()
        {
            this.Types = new List<BeerTypeDetailsResponseViewModel>();
        }

        public ICollection<BeerTypeDetailsResponseViewModel> Types { get; set; }
    }
}
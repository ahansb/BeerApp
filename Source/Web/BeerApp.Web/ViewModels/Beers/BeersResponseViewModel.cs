namespace BeerApp.Web.ViewModels.Beers
{
    using System.Collections.Generic;
    using Beer;
    using Services.Web;

    public class BeersResponseViewModel
    {
        private IIdentifierProvider identifier;

        public BeersResponseViewModel(IIdentifierProvider identifier)
        {
            this.identifier = identifier;
        }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public ICollection<BeerResponseViewModel> Beers { get; set; }

        public string EncodePage(int page)
        {
            return $"{this.identifier.EncodeId(page)}";
        }
    }
}
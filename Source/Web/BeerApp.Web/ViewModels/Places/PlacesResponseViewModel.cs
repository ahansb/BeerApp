namespace BeerApp.Web.ViewModels.Places
{
    using System.Collections.Generic;
    using Place;
    using Services.Web;

    public class PlacesResponseViewModel
    {
        private IIdentifierProvider identifier;

        public PlacesResponseViewModel(IIdentifierProvider identifier)
        {
            this.identifier = identifier;
        }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public ICollection<PlaceResponseViewModel> Places { get; set; }

        public string EncodePage(int page)
        {
            return $"{this.identifier.EncodeId(page)}";
        }
    }
}
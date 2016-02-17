namespace BeerApp.Web.ViewModels.Country
{
    using System.Collections.Generic;
    using Beer;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;
    using Place;
    public class CountryResponseViewModel : IMapFrom<Country>
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SimpleBeerResponseViewModel> Beers { get; set; }

        public ICollection<PlaceResponseViewModel> Places { get; set; }


        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"{identifier.EncodeId(this.Id)}";
            }
        }
    }
}
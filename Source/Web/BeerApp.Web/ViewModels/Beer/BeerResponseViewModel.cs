namespace BeerApp.Web.ViewModels.Beer
{
    using System.Collections.Generic;
    using BeerType;
    using Country;
    using Data.Models;
    using Infrastructure.Mapping;
    using Place;
    using Services.Web;

    public class BeerResponseViewModel : IMapFrom<Beer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual BeerTypeResponseViewModel Type { get; set; }

        public virtual CountryResponseViewModel Country { get; set; }

        public string Description { get; set; }

        public int? ProducedSince { get; set; }

        public decimal AlcoholContaining { get; set; }

        //public virtual ICollection<CommentResponseViewModel> Comments { get; set; }

        public virtual ICollection<PlaceResponseViewModel> Places { get; set; }

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

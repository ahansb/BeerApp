namespace BeerApp.Web.ViewModels.BeerType
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class BeerTypeDetailsViewModel : IMapFrom<BeerType>
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"{identifier.EncodeId(this.Id)}";
            }
        }

        public virtual ICollection<Beer> Beers { get; set; }

    }
}
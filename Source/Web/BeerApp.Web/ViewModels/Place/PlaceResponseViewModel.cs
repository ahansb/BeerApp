namespace BeerApp.Web.ViewModels.Place
{
    using System.Collections.Generic;
    using AutoMapper;
    using Beer;
    using Country;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class PlaceResponseViewModel : IMapFrom<Place>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PlaceType Type { get; set; }

        //public int? CountryId { get; set; }

        public virtual CountryResponseViewModel Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string CreatorName { get; set; }

        public virtual ICollection<SimpleBeerResponseViewModel> Beers { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Place, PlaceResponseViewModel>()
               .ForMember(x => x.CreatorName, opt => opt.MapFrom(x => x.Creator.UserName));
        }
    }
}
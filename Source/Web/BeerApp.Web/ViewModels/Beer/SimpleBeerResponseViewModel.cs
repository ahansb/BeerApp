namespace BeerApp.Web.ViewModels.Beer
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class SimpleBeerResponseViewModel : IMapFrom<Beer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public int? ProducedSince { get; set; }

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
            configuration.CreateMap<Beer, SimpleBeerResponseViewModel>()
               .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Country.Name))
               .ForMember(x => x.Type, opt => opt.MapFrom(x => x.Type.Name));
        }
    }
}
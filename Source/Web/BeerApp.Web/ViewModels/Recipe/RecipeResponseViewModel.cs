namespace BeerApp.Web.ViewModels.Recipe
{
    using AutoMapper;
    using BeerType;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class RecipeResponseViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int BeerTypeId { get; set; }

        public string BeerType { get; set; }

        public string BeerTypeUrl
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"{identifier.EncodeId(this.BeerTypeId)}";
            }
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CreatorName { get; set; }

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
            configuration.CreateMap<Recipe, RecipeResponseViewModel>()
              .ForMember(x => x.CreatorName, opt => opt.MapFrom(x => x.Creator.UserName))
              .ForMember(x => x.BeerType, opt => opt.MapFrom(x => x.BeerType.Name))
              .ForMember(x => x.BeerTypeId, opt => opt.MapFrom(x => x.BeerTypeId));
        }
    }
}
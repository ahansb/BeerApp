namespace BeerApp.Web.ViewModels.BeerType
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Beer;
    using Data.Models;
    using Infrastructure.Mapping;
    using Recipe;
    using Services.Web;

    public class BeerTypeResponseViewModel : IMapFrom<BeerType>,IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SimpleBeerResponseViewModel> Beers { get; set; }

        public ICollection<RecipeResponseViewModel> Recipes { get; set; }

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
            configuration.CreateMap<BeerType, BeerTypeResponseViewModel>()
               .ForMember(x => x.Recipes, opt => opt.MapFrom(x => x.Recipes));
        }
    }
}

namespace BeerApp.Web.Areas.Administration.ViewModels.BeerType
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminBeerTypeViewModel:IMapFrom<BeerType>,IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        public int BeersCount { get; set; }

        public int RecipesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<BeerType, AdminBeerTypeViewModel>()
                           .ForMember(x => x.BeersCount, opt => opt.MapFrom(x => x.Beers.Count))
                           .ForMember(x => x.RecipesCount, opt => opt.MapFrom(x => x.Recipes.Count));
        }
    }
}
namespace BeerApp.Web.Areas.Administration.ViewModels.Recipe
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminRecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [UIHint("BeerTypeIdEditor")]
        public int BeerTypeId { get; set; }

        public string TypeName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public string CreatorName { get; set; }

        public int CommentsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Recipe, AdminRecipeViewModel>()
                           .ForMember(x => x.TypeName, opt => opt.MapFrom(x => x.BeerType.Name))
                           .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count))
                           .ForMember(x => x.CreatorName, opt => opt.MapFrom(x => x.Creator.UserName));
        }
    }
}
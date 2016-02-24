namespace BeerApp.Web.ViewModels.Comment
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentResponseViewModel : IMapFrom<Comment>,IHaveCustomMappings
    {
        public string CreatorPhotoUrl { get; set; }

        public string CreatorName { get; set; }

        public string Content { get; set; }

        //public int? BeerId { get; set; }

        //public int? RecipeId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentResponseViewModel>()
                            .ForMember(x => x.CreatorName, opt => opt.MapFrom(x => x.Creator.UserName))
                            .ForMember(x => x.CreatorPhotoUrl, opt => opt.MapFrom(x => x.Creator.ProfilePhotoUrl));
        }
    }
}
namespace BeerApp.Web.Areas.Administration.ViewModels.Beer
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Web.ViewModels.BeerType;
    using System.Collections.Generic;
    using Web.ViewModels.Country;
    using Services.Data;

    public class AdminBeerViewModel : IMapFrom<Beer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [UIHint("BeerTypeIdEditor")]
        public int BeerTypeId { get; set; }

        public string TypeName { get; set; }

        [Required]
        [UIHint("CountryIdEditor")]
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(1000)]
        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public int? ProducedSince { get; set; }

        [Required]
        public decimal AlcoholContaining { get; set; }

        public string PhotoUrl { get; set; }

        public int VotesCount { get; set; }

        public int CommentsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
       
        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Beer, AdminBeerViewModel>()
                           .ForMember(x => x.VotesCount, opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(v => (int) v.Type) : 0))
                           .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count))
                           .ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.Country.Name))
                           .ForMember(x => x.TypeName, opt => opt.MapFrom(x => x.Type.Name))
                           .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.Description.Length > 100 ? x.Description.Substring(0, 100) + "..." : x.Description));
        }
    }
}
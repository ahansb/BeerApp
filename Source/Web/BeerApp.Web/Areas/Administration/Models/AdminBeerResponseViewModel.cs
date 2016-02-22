namespace BeerApp.Web.Areas.Administration.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using BeerApp.Data.Models;
    using BeerApp.Web.Infrastructure.Mapping;

    public class AdminBeerResponseViewModel : IMapFrom<Beer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public int? ProducedSince { get; set; }

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
            configuration.CreateMap<Beer, AdminBeerResponseViewModel>()
                           .ForMember(x => x.VotesCount, opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(v => (int) v.Type) : 0))
                           .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count))
                           .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Country.Name))
                           .ForMember(x => x.Type, opt => opt.MapFrom(x => x.Type.Name))
                           .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.Description.Length > 100 ? x.Description.Substring(0, 100) + "..." : x.Description));
        }
    }
}
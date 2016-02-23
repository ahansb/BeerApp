namespace BeerApp.Web.Areas.Administration.ViewModels.Place
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using BeerApp.Web.Infrastructure.Mapping;
    using Data.Models;

    public class AdminPlaceViewModel : IMapFrom<Place>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public PlaceType Type { get; set; }
        
        [UIHint("CountryIdEditor")]
        public int? CountryId { get; set; }

        public string CountryName { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        public string PhotoUrl { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public string CreatorName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Place, AdminPlaceViewModel>()
                           .ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.Country.Name))
                           .ForMember(x => x.CreatorName, opt => opt.MapFrom(x => x.Creator.UserName));
        }
    }
}
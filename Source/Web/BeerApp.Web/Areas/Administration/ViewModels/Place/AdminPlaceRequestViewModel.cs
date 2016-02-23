namespace BeerApp.Web.Areas.Administration.ViewModels.Place
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;

    public class AdminPlaceRequestViewModel : IMapTo<Place>, IHaveCustomMappings
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public PlaceType Type { get; set; }

        [Required]
        [UIHint("CountryIdEditor")]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        public string PhotoUrl { get; set; }

        [Required]
        public string CreatorId { get { return System.Web.HttpContext.Current.User.Identity.GetUserId(); } }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<AdminPlaceRequestViewModel, Place>()
                           .ForMember(x => x.CountryId, opt => opt.MapFrom(x => (int?)x.CountryId));
        }
    }
}
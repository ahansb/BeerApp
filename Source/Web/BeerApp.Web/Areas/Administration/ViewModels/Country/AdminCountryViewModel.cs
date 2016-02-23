namespace BeerApp.Web.Areas.Administration.ViewModels.Country
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using BeerApp.Web.Infrastructure.Mapping;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AdminCountryViewModel : IMapFrom<Country>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        public string FlagUrl { get; set; }

        public int BeersCount { get; set; }

        public int PlacesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Country, AdminCountryViewModel>()
                           .ForMember(x => x.BeersCount, opt => opt.MapFrom(x => x.Beers.Count))
                           .ForMember(x => x.PlacesCount, opt => opt.MapFrom(x => x.Places.Count));
        }
    }
}
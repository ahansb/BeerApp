namespace BeerApp.Web.Areas.Administration.ViewModels.Place
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminUpdatePlaceRequestViewModel : IMapTo<Place>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public PlaceType Type { get; set; }
        
        [UIHint("CountryIdEditor")]
        public int? CountryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        public string PhotoUrl { get; set; }
    }
}
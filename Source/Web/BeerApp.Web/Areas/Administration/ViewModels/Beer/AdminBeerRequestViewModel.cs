namespace BeerApp.Web.Areas.Administration.ViewModels.Beer
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminBeerRequestViewModel : IMapTo<Beer>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [UIHint("BeerTypeIdEditor")]
        public int BeerTypeId { get; set; }

        [Required]
        [UIHint("CountryIdEditor")]
        public int CountryId { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int? ProducedSince { get; set; }

        [Required]
        public decimal AlcoholContaining { get; set; }

        public string PhotoUrl { get; set; }

    }
}
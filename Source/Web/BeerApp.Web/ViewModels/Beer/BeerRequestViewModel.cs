namespace BeerApp.Web.ViewModels.Beer
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using Data.Models;

    public class BeerRequestViewModel : IMapTo<Beer>
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public int BeerTypeId { get; set; }

        [Required]
        public int CoutryId { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int? ProducedSince { get; set; }

        [Required]
        public decimal AlcoholContaining { get; set; }

    }
}
namespace BeerApp.Web.ViewModels.Beer
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using Data.Models;
    using System.Collections.Generic;
    using BeerType;
    using Country;
    public class BeerRequestViewModel : IMapTo<Beer>
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public int BeerTypeId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int? ProducedSince { get; set; }

        [Required]
        public decimal AlcoholContaining { get; set; }

        public IEnumerable<SimpleBeerTypeResponseViewModel> BeerTypes { get; set; }

        public IEnumerable<SimpleCountryResponseViewModel> Countries { get; set; }
    }
}
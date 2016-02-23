namespace BeerApp.Web.Areas.Administration.ViewModels.BeerType
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminBeerTypeRequestViewModel : IMapTo<BeerType>
    {
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
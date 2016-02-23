namespace BeerApp.Web.Areas.Administration.ViewModels.Country
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminCountryRequestViewModel : IMapTo<Country>
    {
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        public string FlagUrl { get; set; }
    }
}
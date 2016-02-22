namespace BeerApp.Web.Areas.Administration.ViewModels.Beer
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminUpdateBeerRequestViewModel : AdminBeerRequestViewModel, IMapTo<Beer>
    {
        [Required]
        public int Id { get; set; }
    }
}
namespace BeerApp.Web.Areas.Administration.ViewModels.Recipe
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminUpdateRecipeRequestViewModel : IMapTo<Recipe>
    {
        public int Id { get; set; }

        [Required]
        [UIHint("BeerTypeIdEditor")]
        public int BeerTypeId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }
    }
}
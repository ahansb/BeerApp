namespace BeerApp.Web.Areas.Administration.ViewModels.Recipe
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;

    public class AdminRecipeRequestViewModel : IMapTo<Recipe>
    {
        [Required]
        [UIHint("BeerTypeIdEditor")]
        public int BeerTypeId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }

        [Required]
        public string CreatorId { get { return System.Web.HttpContext.Current.User.Identity.GetUserId(); } }
    }
}
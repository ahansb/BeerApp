namespace BeerApp.Web.ViewModels.Recipe
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BeerType;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;

    public class RecipeRequestViewModel : IMapTo<Recipe>
    {
        [Required]
        public int BeerTypeId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public string CreatorId { get { return System.Web.HttpContext.Current.User.Identity.GetUserId(); } }

        public IEnumerable<SimpleBeerTypeResponseViewModel> BeerTypes { get; set; }

    }
}
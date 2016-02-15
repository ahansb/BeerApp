namespace BeerApp.Web.ViewModels.Place
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;

    public class PlaceRequestViewModel : IMapTo<Place>
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public PlaceType Type { get; set; }

        public int CoutryId { get; set; }

        [Required]
        [MaxLength(40)]
        public string City { get; set; }

        [Required]
        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(40)]
        public string Phone { get; set; }

        [Required]
        public string CreatorId { get { return System.Web.HttpContext.Current.User.Identity.GetUserId(); } }
    }
}
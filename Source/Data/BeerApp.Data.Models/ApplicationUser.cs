namespace BeerApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Place> places;
        private ICollection<Recipe> recipes;
        private ICollection<Comment> comments;

        public ApplicationUser()
        {
            this.places = new HashSet<Place>();
            this.recipes = new HashSet<Recipe>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string LastName { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public virtual ICollection<Place> Places { get { return this.places; } set { this.places = value; } }

        public virtual ICollection<Recipe> Recipes { get { return this.recipes; } set { this.recipes = value; } }

        public virtual ICollection<Comment> Comments { get { return this.comments; } set { this.comments = value; } }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}

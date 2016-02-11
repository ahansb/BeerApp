namespace BeerApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Recipe
    {
        private ICollection<Comment> comments;

        public Recipe()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        public int BeerTypeId { get; set; }

        [ForeignKey("BeerTypeId")]
        public virtual BeerType BeerType { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<Comment> Comments { get { return this.comments; } set { this.comments = value; } }
    }
}

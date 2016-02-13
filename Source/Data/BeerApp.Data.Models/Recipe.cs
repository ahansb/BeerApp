namespace BeerApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;

    public class Recipe : BaseModel<int>
    {
        private ICollection<Comment> comments;

        public Recipe()
        {
            this.comments = new HashSet<Comment>();
        }

        [Required]
        public int BeerTypeId { get; set; }

        [ForeignKey("BeerTypeId")]
        public virtual BeerType BeerType { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<Comment> Comments { get { return this.comments; } set { this.comments = value; } }
    }
}

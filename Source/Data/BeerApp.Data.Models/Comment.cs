namespace BeerApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual ApplicationUser Creator { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(1000)]
        public string Content { get; set; }

        public int? BeerId { get; set; }

        [ForeignKey("BeerId")]
        public virtual Beer Beer { get; set; }

        public int? RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
    }
}

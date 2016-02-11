﻿namespace BeerApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual ApplicationUser Creator { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
namespace BeerApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;

    public class Beer : BaseModel<int>
    {
        private ICollection<Comment> comments;
        private ICollection<Place> places;
        private ICollection<BeerVote> votes;

        public Beer()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<BeerVote>();
            this.places = new HashSet<Place>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int BeerTypeId { get; set; }

        [ForeignKey("BeerTypeId")]
        public virtual BeerType Type { get; set; }

        public int CoutryId { get; set; }

        [ForeignKey("CoutryId")]
        public virtual Country Country { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int? ProducedSince { get; set; }

        [Required]
        public decimal AlcoholContaining { get; set; }

        //[Required]
        public string PhotoUrl { get; set; }

        public virtual ICollection<Comment> Comments { get { return this.comments; } set { this.comments = value; } }

        //public virtual ICollection<Place> Places { get; set; }
        public virtual ICollection<Place> Places { get { return this.places; } set { this.places = value; } }

        public virtual ICollection<BeerVote> Votes { get { return this.votes; } set { this.votes = value; } }
    }
}

namespace BeerApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;

    public class Beer : BaseModel<int>
    {
        private ICollection<Comment> comments;

       // private ICollection<Place> places;
        public Beer()
        {
            this.comments = new HashSet<Comment>();

           // this.places = new HashSet<Place>();
        }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public int BeerTypeId { get; set; }

        [ForeignKey("BeerTypeId")]
        public virtual BeerType Type { get; set; }

        public int CoutryId { get; set; }

        [ForeignKey("CoutryId")]
        public virtual Country Country { get; set; }

        [MaxLength(600)]
        public string Description { get; set; }

        public int? ProducedSince { get; set; }

        [Required]
        public decimal AlcoholContaining { get; set; }

        public virtual ICollection<Comment> Comments { get { return this.comments; } set { this.comments = value; } }

        public virtual ICollection<Place> Places { get; set; }
        //public virtual ICollection<Place> Places { get { return this.places; } set { this.places = value; } }
    }
}

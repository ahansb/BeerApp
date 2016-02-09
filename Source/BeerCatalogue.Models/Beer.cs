namespace BeerCatalogue.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Beer
    {
        private ICollection<Place> places;
        private ICollection<User> users;


        public Beer()
        {
            this.places = new HashSet<Place>();
            this.users = new HashSet<User>();

        }

        public int Id { get; set; }

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

        public virtual ICollection<Place> Places { get { return this.places; } set { this.places = value; } }
        
        public virtual ICollection<User> Users { get { return this.users; } set { this.users = value; } }


    }
}

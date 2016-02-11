namespace BeerApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Country
    {
        private ICollection<Beer> beers;
        private ICollection<Place> places;

        public Country()
        {
            this.beers = new HashSet<Beer>();
            this.places = new HashSet<Place>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Beer> Beers { get { return this.beers; } set { this.beers = value; } }

        public virtual ICollection<Place> Places { get { return this.places; } set { this.places = value; } }

    }
}
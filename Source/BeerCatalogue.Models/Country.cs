namespace BeerCatalogue.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Country
    {
        private ICollection<Beer> beers;
        private ICollection<Bar> bars;
        private ICollection<Store> stores;

        public Country()
        {
            this.beers = new HashSet<Beer>();
            this.bars = new HashSet<Bar>();
            this.stores = new HashSet<Store>();

        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Beer> Beers { get { return this.beers; } set { this.beers = value; } }
        public virtual ICollection<Bar> Bars { get { return this.bars; } set { this.beers = value; } }
        public virtual ICollection<Store> Stores { get { return this.stores; } set { this.= value; } }
    }
}
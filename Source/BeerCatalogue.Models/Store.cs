namespace BeerCatalogue.Models
{
    using System.Collections.Generic;

    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }
    }
}
﻿namespace BeerCatalogue.Models
{
    using System.Collections.Generic;

    public class Bar
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }

    }
}
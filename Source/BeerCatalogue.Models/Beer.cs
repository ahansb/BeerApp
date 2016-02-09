namespace BeerCatalogue.Models
{
    using System.Collections.Generic;
    public class Beer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryType Type { get; set; }

        public Country Country { get; set; }

        public string Description { get; set; }

        public int ProducedSince { get; set; }

        public decimal AlcoholContaining { get; set; }

        public virtual ICollection<Bar> Bars { get; set; }

        public virtual ICollection<Store> Stores { get; set; }

    }
}

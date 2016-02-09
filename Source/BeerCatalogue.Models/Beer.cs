namespace BeerCatalogue.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Beer
    {
        private ICollection<Bar> bars;
        private ICollection<Store> stores;
        private ICollection<User> users;


        public Beer()
        {
            this.bars = new HashSet<Bar>();
            this.stores = new HashSet<Store>();
            this.users = new HashSet<User>();

        }

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public CategoryType Type { get; set; }

        [Required]
        public Country Country { get; set; }

        [MaxLength(600)]
        public string Description { get; set; }

        public int? ProducedSince { get; set; }

        [Required]
        public decimal AlcoholContaining { get; set; }

        public virtual ICollection<Bar> Bars { get { return this.bars; } set { this.bars = value; } }

        public virtual ICollection<Store> Stores { get { return this.stores; } set { this.stores = value; } }

        public virtual ICollection<User> Users { get { return this.users; } set { this.users = value; } }


    }
}

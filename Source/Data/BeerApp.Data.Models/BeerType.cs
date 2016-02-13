namespace BeerApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;

    public class BeerType : BaseModel<int>
    {
        private ICollection<Beer> beers;
        private ICollection<Recipe> recipes;

        public BeerType()
        {
            this.beers = new HashSet<Beer>();
            this.recipes = new HashSet<Recipe>();
        }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Beer> Beers { get { return this.beers; } set { this.beers = value; } }

        public virtual ICollection<Recipe> Recipes { get { return this.recipes; } set { this.recipes = value; } }

    }
}

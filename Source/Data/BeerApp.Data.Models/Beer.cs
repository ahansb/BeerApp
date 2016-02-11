namespace BeerApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Beer
    {
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
    }
}

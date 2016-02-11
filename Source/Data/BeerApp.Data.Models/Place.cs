namespace BeerApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Place
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public PlaceType Type { get; set; }

        public int CoutryId { get; set; }

        [ForeignKey("CoutryId")]
        public virtual Country Country { get; set; }

        [Required]
        [MaxLength(40)]
        public string City { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(40)]
        public string Phone { get; set; }
    }
}

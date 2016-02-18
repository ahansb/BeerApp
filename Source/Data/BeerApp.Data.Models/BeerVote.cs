namespace BeerApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class BeerVote : BaseModel<int>
    {
        [Required]
        public string VoterId { get; set; }

        [ForeignKey("VoterId")]
        public virtual ApplicationUser Voter { get; set; }

        public int BeerId { get; set; }

        [ForeignKey("BeerId")]
        public virtual Beer Beer { get; set; }

        public VoteType Type { get; set; }
    }
}

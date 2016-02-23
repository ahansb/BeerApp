namespace BeerApp.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using Services.Web;

    [Authorize]
    public class BeerVotesController : BaseController
    {
        private readonly IBeerVotesService votes;

        public BeerVotesController(IBeerVotesService votes, IIdentifierProvider identifier)
        {
            this.votes = votes;
        }

        // TODO:Fix logic
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int beerId, int voteType)
        {
            if (voteType > 1)
            {
                voteType = 1;
            }

            if (voteType < -1)
            {
                voteType = -1;
            }

            var userId = this.User.Identity.GetUserId();
            var vote = this.votes.GetByUserAndBeerId(userId, beerId);

            if (vote == null)
            {
                vote = new BeerVote
                {
                    VoterId = userId,
                    BeerId = beerId,
                    Type = (VoteType) voteType
                };
                this.votes.AddVote(vote);
            }
            else
            {
                // Neutralizing vote
                if (vote.Type != (VoteType)voteType)
                {
                    vote.Type = VoteType.Neutral;
                }
                else if (vote.Type == VoteType.Neutral)
                {
                    vote.Type = (VoteType)voteType;
                }

                this.votes.SaveVoteChanges();
            }

            var beerVoteCount = this.votes.CountVotes(beerId);

            return this.Json(new { Count = beerVoteCount });
        }
    }
}

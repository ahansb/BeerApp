namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Common.Repositories.Contracts;
    using BeerApp.Data.Models;
    using Web;

    public class BeerVotesService : IBeerVotesService
    {
        private readonly IDbRepository<BeerVote> beerVotes;
        private readonly IIdentifierProvider identifierProvider;

        public BeerVotesService(IDbRepository<BeerVote> beerVotes, IIdentifierProvider identifierProvider)
        {
            this.beerVotes = beerVotes;
            this.identifierProvider = identifierProvider;
        }

        public void AddVote(BeerVote beerVote)
        {
            this.beerVotes.Add(beerVote);
            this.beerVotes.Save();
        }

        public int CountVotes(int beerId)
        {
            return this.beerVotes.All().Where(v => v.BeerId == beerId).Sum(v => (int)v.Type);
        }

        public BeerVote GetByUserAndBeerId(string userId, int beerId)
        {
            return this.beerVotes.All().FirstOrDefault(v => v.VoterId == userId && v.BeerId == beerId);
        }

        public void SaveVoteChanges()
        {
            this.beerVotes.Save();
        }
    }
}

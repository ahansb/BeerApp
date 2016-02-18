namespace BeerApp.Services.Data
{
    using BeerApp.Data.Models;

    public interface IBeerVotesService
    {
        BeerVote GetByUserAndBeerId(string userId, int beerId);

        void SaveVoteChanges();

        void AddVote(BeerVote beerVote);

        int CountVotes(int beerId);
    }
}

namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Common.Repositories.Contracts;
    using BeerApp.Data.Models;
    using Web;

    public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment> comments;
        private readonly IIdentifierProvider identifierProvider;

        public CommentsService(IDbRepository<Comment> comments, IIdentifierProvider identifierProvider)
        {
            this.comments = comments;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Comment> GetByBeerId(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);

            return this.comments.All().Where(x => x.BeerId == intId).OrderByDescending(x => x.CreatedOn);
        }
    }
}

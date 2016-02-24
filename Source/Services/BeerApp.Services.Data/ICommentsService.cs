namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetByBeerId(string id);
    }
}

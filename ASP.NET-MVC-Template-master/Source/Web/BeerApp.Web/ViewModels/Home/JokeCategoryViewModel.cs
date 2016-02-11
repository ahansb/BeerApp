namespace BeerApp.Web.ViewModels.Home
{
    using BeerApp.Data.Models;
    using BeerApp.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

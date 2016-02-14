namespace BeerApp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;
    using ViewModels.BeerType;
    // TODO: Delete Every Joke
    public class HomeController : BaseController
    {
        private readonly IJokesService jokes;
        private readonly ICategoriesService jokeCategories;
        private readonly IBeerTypesService beerTypes;

        public HomeController(
            IJokesService jokes,
            ICategoriesService jokeCategories,
            IBeerTypesService beerTypes)
        {
            this.jokes = jokes;
            this.jokeCategories = jokeCategories;
            this.beerTypes = beerTypes;
        }

        public ActionResult Index()
        {
            var jokes = this.jokes.GetRandomJokes(3).To<JokeViewModel>().ToList();
            var categories =
                this.Cache.Get(
                    "categories",
                    () => this.jokeCategories.GetAll().To<JokeCategoryViewModel>().ToList(),
                    30 * 60);
            var beerTypes = this.beerTypes.GetAll().To<SimpleBeerTypeResponseViewModel>().ToList();

            var viewModel = new IndexResponseViewModel
            {
                Jokes = jokes,
                Categories = categories,
                BeerTypes = beerTypes
            };

            return this.View(viewModel);
        }
    }
}

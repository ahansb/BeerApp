namespace BeerApp.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<BeerTypeViewModel> BeerTypes { get; set; }

        public IEnumerable<JokeViewModel> Jokes { get; set; }

        public IEnumerable<JokeCategoryViewModel> Categories { get; set; }
    }
}

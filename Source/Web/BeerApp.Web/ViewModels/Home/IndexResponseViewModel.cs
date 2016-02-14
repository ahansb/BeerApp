namespace BeerApp.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using BeerType;

    public class IndexResponseViewModel
    {
        public IEnumerable<SimpleBeerTypeResponseViewModel> BeerTypes { get; set; }

        public IEnumerable<JokeViewModel> Jokes { get; set; }

        public IEnumerable<JokeCategoryViewModel> Categories { get; set; }
    }
}

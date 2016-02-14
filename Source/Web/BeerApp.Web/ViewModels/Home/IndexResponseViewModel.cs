namespace BeerApp.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using BeerType;

    public class IndexResponseViewModel
    {
        public IEnumerable<BeerTypeResponseViewModel> BeerTypes { get; set; }
    }
}

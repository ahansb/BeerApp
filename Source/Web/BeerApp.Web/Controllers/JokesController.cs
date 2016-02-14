namespace BeerApp.Web.Controllers
{
    using System.Web.Mvc;

    using BeerApp.Services.Data;
    using BeerApp.Web.Infrastructure.Mapping;
    using BeerApp.Web.ViewModels.Home;

    public class JokesController : BaseController
    {
        private readonly IJokesService jokes;

        public JokesController(
            IJokesService jokes)
        {
            this.jokes = jokes;
        }

        //public ActionResult ById(string id)
        //{
        //    var joke = this.jokes.GetById(id);
        //    var viewModel = AutoMapperConfig.Configuration.CreateMapper().Map<JokeViewModel>(joke);
        //    return this.View(viewModel);
        //}
    }
}

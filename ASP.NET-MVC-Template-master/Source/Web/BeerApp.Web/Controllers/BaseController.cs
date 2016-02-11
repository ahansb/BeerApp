namespace BeerApp.Web.Controllers
{
    using System.Web.Mvc;

    using BeerApp.Services.Web;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }
    }
}

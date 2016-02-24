namespace BeerApp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    [ValidateInput(false)]
    public class AdminController : Controller
    {
        // GET: Administration/Admin/Menu
        [ChildActionOnly]
        public ActionResult Menu()
        {
            IEnumerable<string> items = new List<string>() { "Beers", "BeerTypes", "Countries", "Places", "Recipes" };
            return this.PartialView("_AdminMenu", items);
        }
    }
}
namespace BeerApp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using Data.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;

    public class AllBeersController : Controller
    {
        private readonly IBeersService beers;
        private ApplicationDbContext db = new ApplicationDbContext();

        public AllBeersController(IBeersService beers)
        {
            this.beers = beers;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Beers_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Beer> beers = this.beers.GetAll();
            DataSourceResult result = beers.ToDataSourceResult(request, beer => new {
                Id = beer.Id,
                Name = beer.Name,
                Description = beer.Description,
                ProducedSince = beer.ProducedSince,
                AlcoholContaining = beer.AlcoholContaining,
                CreatedOn = beer.CreatedOn,
                ModifiedOn = beer.ModifiedOn,
                IsDeleted = beer.IsDeleted,
                DeletedOn = beer.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Beers_Create([DataSourceRequest]DataSourceRequest request, Beer beer)
        {
            if (ModelState.IsValid)
            {
                var entity = new Beer
                {
                    Name = beer.Name,
                    Description = beer.Description,
                    ProducedSince = beer.ProducedSince,
                    AlcoholContaining = beer.AlcoholContaining,
                    CreatedOn = beer.CreatedOn,
                    ModifiedOn = beer.ModifiedOn,
                    IsDeleted = beer.IsDeleted,
                    DeletedOn = beer.DeletedOn
                };

                beer.Id = this.beers.Add(entity);
            }

            return Json(new[] { beer }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Beers_Update([DataSourceRequest]DataSourceRequest request, Beer beer)
        {
            if (ModelState.IsValid)
            {
                var entity = new Beer
                {
                    Id = beer.Id,
                    Name = beer.Name,
                    Description = beer.Description,
                    ProducedSince = beer.ProducedSince,
                    AlcoholContaining = beer.AlcoholContaining,
                    CreatedOn = beer.CreatedOn,
                    ModifiedOn = beer.ModifiedOn,
                    IsDeleted = beer.IsDeleted,
                    DeletedOn = beer.DeletedOn
                };
                this.beers.Update(entity);

                //db.Beers.Attach(entity);
                //db.Entry(entity).State = EntityState.Modified;
                //db.SaveChanges();
            }

            return Json(new[] { beer }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Beers_Destroy([DataSourceRequest]DataSourceRequest request, Beer beer)
        {
            if (ModelState.IsValid)
            {
                var entity = new Beer
                {
                    Id = beer.Id,
                    Name = beer.Name,
                    Description = beer.Description,
                    ProducedSince = beer.ProducedSince,
                    AlcoholContaining = beer.AlcoholContaining,
                    CreatedOn = beer.CreatedOn,
                    ModifiedOn = beer.ModifiedOn,
                    IsDeleted = beer.IsDeleted,
                    DeletedOn = beer.DeletedOn
                };

                this.beers.Delete(entity);
                //db.Beers.Attach(entity);
                //db.Beers.Remove(entity);
                //db.SaveChanges();
            }

            return Json(new[] { beer }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            this.beers.Dispose();
            base.Dispose(disposing);
        }
    }
}

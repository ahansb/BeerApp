using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using BeerApp.Data.Models;
using BeerApp.Data;

namespace BeerApp.Web.Areas.Administration.Controllers
{
    public class BeersAdministrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Beers_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Beer> beers = db.Beers;
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

                db.Beers.Add(entity);
                db.SaveChanges();
                beer.Id = entity.Id;
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

                db.Beers.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
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

                db.Beers.Attach(entity);
                db.Beers.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { beer }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

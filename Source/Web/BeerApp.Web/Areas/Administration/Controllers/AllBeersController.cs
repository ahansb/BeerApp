namespace BeerApp.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data;

    public class AllBeersController : Controller
    {
        private readonly IBeersService beers;

        public AllBeersController(IBeersService beers)
        {
            this.beers = beers;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Beers_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.beers.GetAll().To<AdminBeerResponseViewModel>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Beers_Create([DataSourceRequest]DataSourceRequest request, Beer beer)
        {
            if (this.ModelState.IsValid)
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

                beer.Id = this.beers.AdminCreate(entity);
            }

            return this.Json(new[] { beer }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Beers_Update([DataSourceRequest]DataSourceRequest request, Beer beer)
        {
            if (this.ModelState.IsValid)
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
                this.beers.AdminUpdate(entity);

                //db.Beers.Attach(entity);
                //db.Entry(entity).State = EntityState.Modified;
                //db.SaveChanges();
            }

            return this.Json(new[] { beer }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Beers_Destroy([DataSourceRequest]DataSourceRequest request, Beer beer)
        {
                this.beers.AdminDestroy(beer.Id);
                //db.Beers.Attach(entity);
                //db.Beers.Remove(entity);
                //db.SaveChanges();

            return this.Json(new[] { beer }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            this.beers.AdminDispose();
            base.Dispose(disposing);
        }
    }
}

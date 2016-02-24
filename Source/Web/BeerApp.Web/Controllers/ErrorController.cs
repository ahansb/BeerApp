namespace BeerApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ErrorController : BaseController
    {
        public ViewResult NotFound()
        {
            this.Response.StatusCode = 404;
            return this.View();
        }

        public ViewResult NotAuthorized()
        {
            this.Response.StatusCode = 401;
            return this.View();
        }

        public ViewResult Forbidden()
        {
            this.Response.StatusCode = 403;
            return this.View();
        }

        public ViewResult BadRequest()
        {
            this.Response.StatusCode = 400;
            return this.View();
        }

        public ViewResult InternalServerError()
        {
            this.Response.StatusCode = 500;
            return this.View();
        }
    }
}
using System.Collections.Generic;
using System.Web.Mvc;

namespace BeerApp.Web.Controllers
{
    public class ErrorController : BaseController
    {


        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ViewResult NotAuthorized()
        {
            Response.StatusCode = 401;
            return View();
        }

        public ViewResult Forbidden()
        {
            Response.StatusCode = 403;  
            return View();
        }
        public ViewResult BadRequest()
        {
            Response.StatusCode = 400;  
            return View();
        }
        public ViewResult InternalServerError()
        {
            Response.StatusCode = 500;  
            return View();
        }
    }
}
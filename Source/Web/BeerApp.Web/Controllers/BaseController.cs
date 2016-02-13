namespace BeerApp.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;
    using BeerApp.Services.Web;
    using Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}

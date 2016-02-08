using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeerCatalogue.Web.Startup))]
namespace BeerCatalogue.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

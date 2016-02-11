using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(BeerApp.Web.Startup))]

namespace BeerApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreAppWeb.Startup))]
namespace StoreAppWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

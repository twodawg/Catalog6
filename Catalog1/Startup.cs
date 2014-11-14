using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Catalog1.Startup))]
namespace Catalog1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bodega.dev.Startup))]
namespace Bodega.dev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

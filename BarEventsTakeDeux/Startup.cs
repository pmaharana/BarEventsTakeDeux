using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarEventsTakeDeux.Startup))]
namespace BarEventsTakeDeux
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

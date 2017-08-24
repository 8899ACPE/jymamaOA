using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jymama.WebSite.Startup))]
namespace jymama.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

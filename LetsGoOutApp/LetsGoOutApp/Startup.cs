using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LetsGoOutApp.Startup))]
namespace LetsGoOutApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

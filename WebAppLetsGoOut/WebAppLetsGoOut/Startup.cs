using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppLetsGoOut.Startup))]
namespace WebAppLetsGoOut
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

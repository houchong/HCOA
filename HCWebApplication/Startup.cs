using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HCWebApplication.Startup))]
namespace HCWebApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

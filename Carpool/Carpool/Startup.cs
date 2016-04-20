using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute("CarpoolConfig", typeof(Carpool.Startup))]
namespace Carpool
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

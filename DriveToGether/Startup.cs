using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DriveToGether.Startup))]
namespace DriveToGether
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

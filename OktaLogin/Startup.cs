using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OktaLogin.Startup))]
namespace OktaLogin
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

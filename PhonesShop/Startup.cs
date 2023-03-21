using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhonesShop.Startup))]
namespace PhonesShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

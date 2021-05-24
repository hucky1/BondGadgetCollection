using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BondGadgetsEntity.Startup))]
namespace BondGadgetsEntity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
    
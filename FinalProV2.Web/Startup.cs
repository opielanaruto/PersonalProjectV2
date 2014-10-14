using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalProV2.Web.Startup))]
namespace FinalProV2.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

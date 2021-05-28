using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LagerverwaltungWH.Web.Startup))]
namespace LagerverwaltungWH.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

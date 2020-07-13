using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaioComputers.Startup))]
namespace CaioComputers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

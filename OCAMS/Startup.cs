using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OCAMS.Startup))]
namespace OCAMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

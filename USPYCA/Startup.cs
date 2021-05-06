using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(USPYCA.Startup))]
namespace USPYCA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

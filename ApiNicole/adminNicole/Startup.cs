using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(adminNicole.Startup))]
namespace adminNicole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

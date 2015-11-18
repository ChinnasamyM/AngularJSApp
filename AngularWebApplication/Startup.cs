using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularWebApplication.Startup))]
namespace AngularWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

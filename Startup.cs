using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthyGrove.Startup))]
namespace HealthyGrove
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


    }
}

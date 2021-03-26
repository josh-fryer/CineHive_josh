using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cinehive.Startup))]
namespace Cinehive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }   
    }
}

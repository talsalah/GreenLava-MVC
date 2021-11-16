using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenLava.WebMVC.Startup))]
namespace GreenLava.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

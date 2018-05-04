using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppWood.Startup))]
namespace WebAppWood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

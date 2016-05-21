using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAplikacijaMvc.Startup))]
namespace WebAplikacijaMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

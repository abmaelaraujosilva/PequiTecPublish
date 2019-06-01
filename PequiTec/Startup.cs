using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PequiTec.Startup))]
namespace PequiTec
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Vidily.Startup))]
namespace MVC_Vidily
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

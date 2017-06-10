using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2015116292_MVC.Startup))]
namespace _2015116292_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

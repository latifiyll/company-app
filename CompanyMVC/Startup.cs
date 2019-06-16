using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyMVC.Startup))]
namespace CompanyMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

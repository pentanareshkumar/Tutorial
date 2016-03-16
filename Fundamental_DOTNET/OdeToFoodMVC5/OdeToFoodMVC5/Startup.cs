using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OdeToFoodMVC5.Startup))]
namespace OdeToFoodMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

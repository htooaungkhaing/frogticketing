using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FrogProject.Startup))]
namespace FrogProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

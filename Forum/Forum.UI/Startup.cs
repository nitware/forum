using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Forum.UI.Startup))]
namespace Forum.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

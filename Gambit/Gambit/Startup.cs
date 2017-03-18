using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gambit.Startup))]
namespace Gambit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

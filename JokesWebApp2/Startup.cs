using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JokesWebApp2.Startup))]
namespace JokesWebApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

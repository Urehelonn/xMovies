using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(xMovies.Startup))]
namespace xMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesStore.Web.Startup))]
namespace MoviesStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

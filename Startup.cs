using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComicStore.Startup))]
namespace ComicStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

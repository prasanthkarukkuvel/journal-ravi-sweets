using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Journal7.Startup))]
namespace Journal7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

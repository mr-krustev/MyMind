using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(RightoGo.Web.Startup))]

namespace RightoGo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}

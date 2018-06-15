using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhoneBookWeb.Startup))]
namespace PhoneBookWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

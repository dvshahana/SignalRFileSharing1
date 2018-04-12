using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(M8_C11_w01.Startup))]
namespace M8_C11_w01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}

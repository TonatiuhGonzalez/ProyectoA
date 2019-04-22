using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MainFrame_UI.Startup))]
namespace MainFrame_UI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(Project_A.Startup))]
namespace Project_A
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }


}

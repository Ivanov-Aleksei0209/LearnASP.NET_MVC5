using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloMvcAplication.Startup))]
namespace HelloMvcAplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

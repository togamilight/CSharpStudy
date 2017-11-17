using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iBatisUnityTest.Startup))]
namespace iBatisUnityTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

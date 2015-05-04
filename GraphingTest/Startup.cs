using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GraphingTest.Startup))]
namespace GraphingTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

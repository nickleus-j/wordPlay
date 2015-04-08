using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaterialAnagram.Startup))]
namespace MaterialAnagram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

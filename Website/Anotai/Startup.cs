using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Anotai.Startup))]
namespace Anotai
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}

using Microsoft.Owin;
using Owin;
using Microsoft.Extensions.DependencyInjection;

[assembly: OwinStartup(typeof(SapoLoyalty.Startup))]
namespace SapoLoyalty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            
            ConfigureAuth(app);

        }

        public void ConfigureServices(IServiceCollection services)
        {
           
        }
    }
}

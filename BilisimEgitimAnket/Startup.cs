using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BilisimEgitimAnket.Startup))]
namespace BilisimEgitimAnket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

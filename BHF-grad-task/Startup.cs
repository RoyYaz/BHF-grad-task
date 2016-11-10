using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BHF_grad_task.Startup))]
namespace BHF_grad_task
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeMark.Startup))]
namespace CodeMark
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

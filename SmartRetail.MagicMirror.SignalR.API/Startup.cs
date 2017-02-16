using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using SmartRetail.MagicMirror.SignalR.API.Performance;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(SmartRetail.MagicMirror.SignalR.API.Startup))]

namespace SmartRetail.MagicMirror.SignalR.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            app.MapSignalR(hubConfiguration);


            var performanceEngine = new PerformanceEngine(800);
            Task.Factory.StartNew(async () => await performanceEngine.OnPerformanceReader());
        }
    }
}

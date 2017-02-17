using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using SmartRetail.MagicMirror.SignalR.API.Hubs;
using System;
using SmartRetail.MagicMirror.SignalR.API.Models;
using System.Collections.Generic;
using SmartRetail.MagicMirror.SignalR.API.Performance;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(SmartRetail.MagicMirror.SignalR.API.Startup))]

namespace SmartRetail.MagicMirror.SignalR.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Branch the pipeline here for requests that start with "/signalr"
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    EnableDetailedErrors = true,
                    EnableJSONP = true
                };
               
                map.RunSignalR(hubConfiguration);

                var performanceEngine = new PerformanceEngine(800);
                Task.Factory.StartNew(async () => await performanceEngine.OnPerformanceReader());

            });
        }
    }
}

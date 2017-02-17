using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using SmartRetail.MagicMirror.SignalR.API.Performance;
using Microsoft.Owin.Cors;
using SmartRetail.MagicMirror.SignalR.API.Hubs;
using System;
using SmartRetail.MagicMirror.SignalR.API.Models;
using System.Collections.Generic;

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

            //var hub = GlobalHost.ConnectionManager.GetHubContext<ReaderHub>();
            //var list = new List<ProductModel>()
            //{
            //    new ProductModel() { Description ="REMERA ESCOTE V", ExternalCode = "REMV005" },
            //    new ProductModel() { Description ="POLLERA LARGA FIT", ExternalCode = "POLFIT895" },
            //    new ProductModel() { Description ="COLLAR PERLAS", ExternalCode = "COLPER01" }
            //};

            //hub.Clients.All.broadcastPerformance(list);
            //hub.Clients.All.serverTime(DateTime.UtcNow.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using SmartRetail.MagicMirror.SignalR.API.Models;

namespace SmartRetail.MagicMirror.SignalR.API.Hubs
{
    public class ReaderHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void SendPerformance(IList<ProductModel> productModels)
        {
            Clients.All.broadcast(productModels);
        }

        public void Communicate(string messageId, string message)
        {
            Clients.All.addNewMessageToPage(messageId, message);
        }

        public void Heartbeat()
        {
            Clients.All.heartbeat();
        }

        public dynamic ReadingFor()
        {
            /*
            return PerformanceEngine.ServiceCounters.Select(counter =>
                new
                {
                    MachineName = counter.CounterName,
                    CategoryName = counter.CategoryName,
                    CounterName = counter.CounterName,
                    InstanceName = counter.InstanceName
                });*/
            return new List<ProductModel>()
            {
                new ProductModel() { Description ="REMERA ESCOTE V", ExternalCode = "REMV005" },
                new ProductModel() { Description ="POLLERA LARGA FIT", ExternalCode = "POLFIT895" }
            };
        }

        public override Task OnConnected()
        {
            return (base.OnConnected());
        }

        public string GetServerTime()
        {
            return DateTime.UtcNow.ToString();
        }
    }
}
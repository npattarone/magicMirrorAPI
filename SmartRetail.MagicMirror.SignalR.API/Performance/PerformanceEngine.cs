using Microsoft.AspNet.SignalR;
using SmartRetail.MagicMirror.SignalR.API.Hubs;
using SmartRetail.MagicMirror.SignalR.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartRetail.MagicMirror.SignalR.API.Performance
{
    public class PerformanceEngine
    {
        private IHubContext _hubs;
        private readonly int _pollIntervalMillis;
        static Random _cpuRand;
        static Random _memRand;
        static Random _netIn;
        static Random _netOut;
        static Random _diskRd;
        static Random _diskWt;

        public PerformanceEngine(int pollIntervalMillis)
        {
            //HostingEnvironment.RegisterObject(this);
            _hubs = GlobalHost.ConnectionManager.GetHubContext<ReaderHub>();
            _pollIntervalMillis = pollIntervalMillis;
            _cpuRand = new Random();
            _memRand = new Random();
            _netIn = new Random();
            _netOut = new Random();
            _diskRd = new Random();
            _diskWt = new Random();
        }

        public async Task OnPerformanceReader()
        {
            var list = new List<ProductModel>()
            {
                new ProductModel() { Description ="REMERA ESCOTE V", ExternalCode = "REMV005", Id = "69871" },
                new ProductModel() { Description ="POLLERA LARGA FIT", ExternalCode = "POLFIT895" , Id = "7963"},
                new ProductModel() { Description ="COLLAR PERLAS", ExternalCode = "COLPER01", Id = "876523" }
            };
            //Monitor for infinity!
            while (true)
            {
                await Task.Delay(_pollIntervalMillis);

                //List of performance models that is loaded up on every itteration.
                var performanceModels = new List<ProductModel>();

                foreach (var performanceCounter in list)
                {
                    try
                    {
                        switch (performanceCounter.Description)
                        {
                            case "REMERA ESCOTE V":
                                performanceModels.Add(new ProductModel
                                {
                                    Description = "REMERA ESCOTE V",
                                    ExternalCode = "REMV005",
                                    Id = "69871"

                                });
                                break;
                            case "COLLAR PERLAS":
                                performanceModels.Add(new ProductModel
                                {
                                    Description = "COLLAR PERLAS",
                                    ExternalCode = "COLPER01",
                                    Id = "876523"

                                });
                                break;
                            case "POLLERA LARGA FIT":
                                performanceModels.Add(new ProductModel
                                {
                                    Description = "POLLERA LARGA FIT",
                                    ExternalCode = "POLFIT895",
                                    Id = "7963"

                                });
                                break;
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        //Trace.TraceError("Performance with Performance counter {0}.", performanceCounter.MachineName + performanceCounter.CategoryName + performanceCounter.CounterName);
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }

                _hubs.Clients.All.broadcastPerformance(performanceModels);
                _hubs.Clients.All.serverTime(DateTime.UtcNow.ToString());
            }
        }

        public void Stop(bool immediate)
        {
            //HostingEnvironment.UnregisterObject(this);
        }

        #region Helpers

        private static string GetCurrentProcessInstanceName()
        {
            Process proc = Process.GetCurrentProcess();
            int pid = proc.Id;
            return GetProcessInstanceName(pid);
        }

        private static string GetProcessInstanceName(int pid)
        {
            PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");

            string[] instances = cat.GetInstanceNames();
            foreach (string instance in instances)
            {

                using (PerformanceCounter cnt = new PerformanceCounter("Process",
                     "ID Process", instance, true))
                {
                    int val = (int)cnt.RawValue;
                    if (val == pid)
                    {
                        return instance;
                    }
                }
            }
            throw new Exception("Could not find performance counter " +
                "instance name for current process. This is truly strange ...");
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Facilities.Logging;
using Castle.Services.Logging.NLogIntegration;
using Topshelf;

namespace Luna.Service.HangFireDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(config =>
            {
                config.Service<ServiceMain>();
                config.SetDisplayName("演示");
                config.SetServiceName("TopshelfDemo");
                config.UseNLog();
            });
        }
    }
}

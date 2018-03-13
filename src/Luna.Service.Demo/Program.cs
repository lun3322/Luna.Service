using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.Services.Logging.NLogIntegration;

namespace Luna.Service.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var starter = Starter.Create<Runner>())
            {
                starter.Container.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));

                starter.Run();
            }
        }
    }
}


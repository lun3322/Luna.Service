using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Facilities.Logging;
using Castle.Services.Logging.NLogIntegration;
using Topshelf;

namespace Luna.Service.TopshelfDemo
{
    public class ServiceMain : ServiceControl
    {
        private readonly Starter _starter;
        public ServiceMain()
        {
            _starter = Starter.Create<Runner>();
            _starter.Container.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
        }

        public bool Start(HostControl hostControl)
        {
            _starter.Run();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _starter.Dispose();
            return true;
        }
    }
}

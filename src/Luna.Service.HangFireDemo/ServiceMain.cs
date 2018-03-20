using Castle.Facilities.Logging;
using Castle.Services.Logging.NLogIntegration;
using Hangfire;
using Topshelf;

namespace Luna.Service.HangFireDemo
{
    public class ServiceMain : ServiceControl
    {
        private readonly Starter _starter;
        public ServiceMain()
        {
            _starter = Starter.Create<Runner>();
            _starter.Container.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            GlobalConfiguration.Configuration.UseSqlServerStorage("default");
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

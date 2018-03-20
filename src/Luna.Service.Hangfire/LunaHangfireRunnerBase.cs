using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Windsor;

namespace Luna.Service.Hangfire
{
    public abstract class LunaHangfireRunnerBase : LunaRunnerBase
    {
        private BackgroundJobServer _backgroundJobServer;
        public Starter Starter { get; set; }
        public override void Init()
        {
            base.Init();
            JobActivator.Current = new WindsorJobActivator(Starter.Container.Kernel);
            _backgroundJobServer = new BackgroundJobServer();
        }

        public override void Stop()
        {
            _backgroundJobServer.Dispose();
        }
    }
}

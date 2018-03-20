using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Windsor;
using Luna.Service.App;
using Luna.Service.Hangfire;

namespace Luna.Service.HangFireDemo
{
    public class Runner : LunaHangfireRunnerBase
    {
        public override void Run()
        {
            RecurringJob.AddOrUpdate<IJobService>(service => service.OutputLog(), Cron.Minutely);
        }
    }
}

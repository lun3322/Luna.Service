using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luna.Service.App;

namespace Luna.Service.TopshelfDemo
{
    public class Runner : LunaRunnerBase
    {
        private readonly ITimerService _timerService;

        public Runner(ITimerService timerService)
        {
            _timerService = timerService;
        }

        public override void Run()
        {
            Logger.Info("runner.run");
            _timerService.Start();
        }
    }
}

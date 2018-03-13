using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luna.Service.App;

namespace Luna.Service.Demo
{
    public class Runner : LunaRunnerBase
    {
        private readonly IDemoService _demoService;

        public Runner(IDemoService demoService)
        {
            _demoService = demoService;
        }

        public override void Run()
        {
            var message = _demoService.GetMessage();
            Logger.Info(message);
            Logger.Info("ok");
        }
    }
}

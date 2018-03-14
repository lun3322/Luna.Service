﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luna.Service.App;
using Luna.Service.Model;

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
            var message = _demoService.GetMessage("test");
            Logger.Info(message);
            var strModel = _demoService.GetDemo(new DemoModel("名字", 33));
            Logger.Info(strModel);
            Logger.Info("ok");
        }
    }
}

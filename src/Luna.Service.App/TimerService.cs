using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Luna.Service.App
{
    public class TimerService : LunaServiceBase, ITimerService
    {
        private readonly Timer _timer;

        public TimerService()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, args) => Logger.Info($"当前时间: {DateTime.Now}");
        }

        public void Start()
        {
            _timer.Start();
        }
    }
}

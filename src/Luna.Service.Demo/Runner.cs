using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luna.Service.App;
using Luna.Service.Application;
using Luna.Service.Model;

namespace Luna.Service.Demo
{
    public class Runner : LunaRunnerBase
    {
        private readonly IDemoService _demoService;
        private readonly ICacheDemoService _cacheDemoService;

        public Runner(IDemoService demoService, ICacheDemoService cacheDemoService)
        {
            _demoService = demoService;
            _cacheDemoService = cacheDemoService;
        }

        public override void Run()
        {
            var cacheManager = Cache.GetCacheManager<string>("test_demo");
            var message = _demoService.GetMessage("test");
            cacheManager.Add("GetMessage", message);
            Logger.Info(message);
            var strModel = _demoService.GetDemo(new DemoModel("名字", 33));
            Logger.Info(strModel);
            Logger.Info("ffffffff");

            var cachedMsg = cacheManager.Get<string>("GetMessage");
            Logger.Info($"cachedMsg: {cachedMsg}");

            _cacheDemoService.Add("你好啊");
            var cacheString = _cacheDemoService.Get();
            Logger.Info($"service中缓存的字符串 {cacheString}");

            var services = Container.ResolveAll<ILunaService>();
            Logger.Info($"已注册的service个数: {services.Length}");
        }

        public override void Stop()
        {
            Logger.Info("runner stop");
        }
    }
}

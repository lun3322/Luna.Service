using Luna.Service.Audit;
using Luna.Service.Model;

namespace Luna.Service.App
{
    [Audited]
    public class DemoService : LunaServiceBase, IDemoService
    {
        public string GetMessage(string name)
        {
            Logger.Info($"GetMessage {name}");
            return "测试";
        }

        public string GetDemo(DemoModel model)
        {
            var msg = $"{model.Name}: {model.Age}";
            return msg;
        }
    }
}

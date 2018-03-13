namespace Luna.Service.App
{
    public class DemoService : LunaServiceBase, IDemoService
    {
        public string GetMessage()
        {
            Logger.Info("GetMessage");
            return "测试";
        }
    }
}

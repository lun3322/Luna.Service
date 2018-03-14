using Luna.Service.Application;
using Luna.Service.Model;

namespace Luna.Service.App
{
    public interface IDemoService : ILunaService
    {
        string GetMessage(string name);

        string GetDemo(DemoModel model);
    }
}

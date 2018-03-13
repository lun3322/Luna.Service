using Luna.Service.Application;

namespace Luna.Service.App
{
    public interface IDemoService : ILunaService
    {
        string GetMessage();
    }
}

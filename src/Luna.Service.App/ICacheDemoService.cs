using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luna.Service.Application;

namespace Luna.Service.App
{
    public interface ICacheDemoService : ILunaService
    {
        void Add(string value);
        string Get();
    }
}

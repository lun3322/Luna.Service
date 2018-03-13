using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luna.Service.Core.Application;

namespace Luna.Service.App
{
    public interface ITimerService : ILunaService
    {
        void Start();
    }
}

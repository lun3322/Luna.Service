using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Luna.Service.Core.Dependency;

namespace Luna.Service.Core
{
    public interface IRunner : ISingletonDependency
    {
        void Run();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;

namespace Luna.Service.Dependency
{
    internal class IocManager
    {
        public static WindsorContainer Container { get; set; }
    }
}

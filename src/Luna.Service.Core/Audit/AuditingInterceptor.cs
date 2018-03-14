using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Newtonsoft.Json;

namespace Luna.Service.Audit
{
    public class AuditingInterceptor : IInterceptor
    {
        public ILogger Logger { get; set; }

        public AuditingInterceptor()
        {
            Logger = NullLogger.Instance;
        }

        public void Intercept(IInvocation invocation)
        {
            Logger.Debug($"call {invocation.Method.Name} args: {JsonConvert.SerializeObject(invocation.Arguments)}");
            invocation.Proceed();
        }
    }
}

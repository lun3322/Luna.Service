using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Service.App
{
    public class JobService : LunaServiceBase, IJobService
    {
        public void OutputLog()
        {
            Logger.Info(DateTimeOffset.Now.ToString());
        }
    }
}

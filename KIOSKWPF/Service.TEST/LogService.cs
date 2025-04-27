using KIOSKWPF.Service.IF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKWPF.Service.TEST
{
    internal class LogService : ILogService
    {
        public void WriteLog(string log, enLogLevel level = enLogLevel.INFO)
        {
            Trace.WriteLine($"{DateTime.Now.ToString("yyyyMMdd_hhmmss")} [{level.ToString()}] {log}");
        }
    }
}

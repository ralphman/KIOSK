using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKWPF.Service.IF
{
    internal enum enLogLevel
    {
        INFO = 0,
        WARN = 1,
        ERROR = 2,
        FATAL = 3
    }

    internal interface ILogService
    {
        void WriteLog(string log, enLogLevel level = enLogLevel.INFO);
    }
}

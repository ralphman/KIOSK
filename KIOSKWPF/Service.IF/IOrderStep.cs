using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKWPF.Service.IF
{
    internal enum enStep
    {
        HOME = 0,

        ORDER = 1,

        BASKET = 2,

        SELECT_MEDIA = 3,

        EXECUTE_PAY = 4
    }

    internal interface IOrderStep
    {
        CompleteDelegate Complete { get; set; }
    }

    internal delegate void CompleteDelegate(enStep step, int result);
}

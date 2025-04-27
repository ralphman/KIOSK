using KIOSKWPF.Service.IF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKWPF.Service.IMP
{
    internal class OrderService
    {
        protected IPrinterService Printer { get; }

        protected IPayService Pay { get; }

        public OrderService(IPrinterService printer, IPayService pay)
        {
            Printer = printer;
            Pay = pay;
        }
    }
}

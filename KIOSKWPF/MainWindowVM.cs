using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KIOSKWPF
{
    internal class MainWindowVM : MVVMBase
    {
        public MainWindowVM()
        {
            OrderVM = new OrderVM();
        }

        public OrderVM OrderVM { get; set; } // DI를 이용해 보도록 하자
    }
}

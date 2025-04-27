using KIOSKWPF.VM;
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
        public IServiceProvider Provider { get; }

        public MainWindowVM(IServiceProvider provider)
        {
            OrderVM = new OrderVM(provider);
            Provider = provider;

            InitOrder();
        }

        public OrderVM OrderVM { get; set; } // DI를 이용해 보도록 하자

        private void InitOrder()
        {
            OrderVM.Init();
        }
    }
}

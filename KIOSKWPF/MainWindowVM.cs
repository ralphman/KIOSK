using KIOSKWPF.Service.IF;
using KIOSKWPF.VM;
using Microsoft.Extensions.DependencyInjection;
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

            // 1. 환경 정보 로드

            // 2. 메뉴 정보 구성
            var dbService = Provider.GetRequiredService<IDBService>();
            dbService.LoadMenuData();

            // 3. 프로그램 기동


            InitOrder();
        }

        public OrderVM OrderVM { get; set; } // DI를 이용해 보도록 하자

        private void InitOrder()
        {
            OrderVM.Init();
        }
    }
}

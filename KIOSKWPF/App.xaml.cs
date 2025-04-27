using KIOSKWPF.Service.IF;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using System.Windows;

#if DEBUG
using KIOSKWPF.Service.TEST;
#else
using KIOSKWPF.Service.IMP;
#endif

namespace KIOSKWPF
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private MainWindow _window;
        private MainWindowVM _vm;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var service = new ServiceCollection();
            service.AddSingleton<INWService, NWService>();
            service.AddSingleton<IDBService, DBService>();
            service.AddSingleton<IPrinterService, PrinterService>();
            service.AddSingleton<IPayService, PayService>();
            service.AddTransient<IOrderService, OrderService>();

            var provider = service.BuildServiceProvider();

            _vm = new MainWindowVM(provider);
            _window = new MainWindow();
            _window.DataContext = _vm;

            _window.Show();
        }
    }
}

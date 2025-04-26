using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using System.Windows;

namespace KIOSKWPF
{
    public interface IDBService
    {
        void LoadDB();
    }

    public interface IDataService
    {
        void LoadData();
    }

    public class DBService : IDBService
    {
        public void LoadDB() 
        {
            // DB에서 데이터 로드 하기
        }
    }

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
            service.AddSingleton<IDBService, DBService>();

            _vm = new MainWindowVM();
            _window = new MainWindow();

            _window.DataContext = _vm;

            _window.Show();
        }
    }
}

using KIOSKWPF.Service.IF;
using Microsoft.Extensions.DependencyInjection;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KIOSKWPF.VM
{
    internal class OrderVM : MVVMBase
    {
        protected IServiceProvider Provider { get; }

        protected IOrderService OrderService { get; set; }

        public OrderVM(IServiceProvider provider)
        {
            Provider = provider;
        }

        public void Init()
        {
            var db = Provider.GetRequiredService<IDBService>();
            MenuItems = db.MenuItems;

            OrderService = Provider.GetRequiredService<IOrderService>();
            OrderService.OrderUpdated = OrderUpdated;

            OrderStep = OrderService;

            // UX 초기화
            IsFirstCat = true;
            SelectCommand.Execute("Hamburger");
        }
           
        private void OrderUpdated()
        {
            OnPropertyChanged(nameof(Total));
        }

        public bool IsFirstCat
        {
            get => _isFirstCat; 
            set
            {
                _isFirstCat = value;
                OnPropertyChanged();
            }
        }
        private bool _isFirstCat = true;

        public ObservableCollection<MenuItem> Items { get; } = new ObservableCollection<MenuItem>();

        public Dictionary<enCategory, List<MenuItem>> MenuItems { get; set; }

        public int Total => OrderService.TotalPrice;

        public ObservableCollection<OrderItem> OrderItems => OrderService.OrderItems;

        public CompleteDelegate OrderComplete
        {
            get => OrderService.Complete;
            set => OrderService.Complete = value;
        }

        //------------------ Commands ------------------//
        public ICommand SelectCommand
        {
            get
            {
                if (_selectCommand == null)
                {
                    _selectCommand = new RelayCommand(SelectCommand_Execute);
                }

                return _selectCommand;
            }
        }
        private RelayCommand _selectCommand;

        private void SelectCommand_Execute(object param)
        {
            if (param is string option)
            {
                Items.Clear();

                switch (option)
                {
                    case "Hamburger":
                        {
                            MenuItems[enCategory.Hamburger].ForEach(e => Items.Add(e));
                        }
                        break;
                    case "Beverage":
                        {
                            MenuItems[enCategory.Beverage].ForEach(e => Items.Add(e));
                        }
                        break;
                    case "Desert":
                        {
                            MenuItems[enCategory.Desert].ForEach(e => Items.Add(e));
                        }
                        break;
                }
            }
        }

        public ICommand MenuCommand
        {
            get
            {
                if (_menuCommand == null)
                {
                    _menuCommand = new RelayCommand(MenuCommand_Execute);
                }

                return _menuCommand;
            }
        }
        private RelayCommand _menuCommand;

        private void MenuCommand_Execute(object param)
        {
            if (param is MenuItem menuItem)
            {
                OrderService.AddMenu(menuItem);
            }
        }

        public ICommand AddOrderCommand
        {
            get
            {
                if (_addOrderCommand == null)
                {
                    _addOrderCommand = new RelayCommand(AddOrderCommand_Execute);
                }

                return _addOrderCommand;
            }
        }
        private RelayCommand _addOrderCommand;

        private void AddOrderCommand_Execute(object param)
        {
            if (param is OrderItem orderItem)
            {
                OrderService.AddOrder(orderItem);
            }
        }

        public ICommand DeleteOrderCommand
        {
            get
            {
                if (_deleteOrderCommand == null)
                {
                    _deleteOrderCommand = new RelayCommand(DeleteOrderCommand_Execute);
                }

                return _deleteOrderCommand;
            }
        }
        private RelayCommand _deleteOrderCommand;

        private void DeleteOrderCommand_Execute(object param)
        {
            if (param is OrderItem orderItem)
            {
                OrderService.DeleteOrder(orderItem);
            }
        }
    }
}

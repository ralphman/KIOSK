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
        public OrderVM()
        {
#if DEBUG
            MakeDummyData();
#endif
        }

        public ObservableCollection<MenuItem> Items { get; } = new ObservableCollection<MenuItem>();

        public ObservableCollection<OrderItem> OrderItems { get; } = new ObservableCollection<OrderItem>();

        public Dictionary<enCategory, List<MenuItem>> MenuItems { get; } = new Dictionary<enCategory, List<MenuItem>>();

        public int Total
        {
            get => _total;
            set
            {
                if (_total != value)
                {
                    _total = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _total;

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
                    case "Hamberger":
                        {
                            MenuItems[enCategory.Hamberger].ForEach(e => Items.Add(e));
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
                var order = OrderItems.FirstOrDefault(d => d.Name == menuItem.Name);

                if (order == null)
                {
                    order = new OrderItem(menuItem, 1);
                    OrderItems.Add(order);
                }
                else
                {
                    order.Add();
                }

                UpdateOrderInfo();
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
                orderItem.Add();

                UpdateOrderInfo();
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
                orderItem.Delete();

                if (orderItem.Count == 0)
                {
                    OrderItems.Remove(orderItem);
                }

                UpdateOrderInfo();
            }
        }


        private void MakeDummyData()
        {
            string directory = System.AppDomain.CurrentDomain.BaseDirectory;

            // DB에서 데이터를 읽어오는 용도로 하면 된다.
            var hambergers = new List<MenuItem>()
            {
                new Hamberger() { Name = "불고기버거", Price = 5000, ImagePath=Path.Combine(directory, @"Image/Food/hamberger_1.png") },
                new Hamberger() { Name = "새우버거", Price = 7000, ImagePath=Path.Combine(directory, @"Image/Food/hamberger_2.png") },
                new Hamberger() { Name = "오징어버거", Price = 6500, ImagePath=Path.Combine(directory, @"Image/Food/hamberger_3.png") },
            };

            var beverages = new List<MenuItem>()
            {
                new Beverage() { Name = "콜라", Price = 1000, ImagePath=Path.Combine(directory, @"Image/Food/beverage_1.png") },
                new Beverage() { Name = "사이다", Price = 1000, ImagePath=Path.Combine(directory, @"Image/Food/beverage_2.png") },
                new Beverage() { Name = "오렌지주스", Price = 2500, ImagePath=Path.Combine(directory, @"Image/Food/beverage_3.png") },
            };

            var deserts = new List<MenuItem>()
            {
                new Desert() { Name = "아이스크림", Price = 2000, ImagePath=Path.Combine(directory, @"Image/Food/desert_1.png") },
                new Desert() { Name = "마카롱", Price = 3000, ImagePath=Path.Combine(directory, @"Image/Food/desert_2.png") },
            };

            MenuItems.Add(enCategory.Hamberger, hambergers);
            MenuItems.Add(enCategory.Beverage, beverages);
            MenuItems.Add(enCategory.Desert, deserts);

            hambergers.ForEach(d => Items.Add(d));
        }

        private void UpdateOrderInfo()
        {
            int total = 0;
            foreach (var order in OrderItems)
            {
                total += order.Price;
            }

            Total = total;
        }
    }
}

using KIOSKWPF.Service.IF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKWPF.Service.TEST
{
    internal class OrderService : IOrderService
    {
        protected IPrinterService Printer { get; }

        protected IPayService Pay { get; }

        public OrderService(IPrinterService printer, IPayService pay)
        {
            Printer = printer;
            Pay = pay;
            OrderItems = new ObservableCollection<OrderItem>();
        }

        public int TotalPrice { get; protected set; }

        public Action OrderUpdated { get; set; }

        public ObservableCollection<OrderItem> OrderItems { get; }

        public bool AddMenu(MenuItem menuItem)
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

            return true;
        
        }

        public bool AddOrder(OrderItem orderItem)
        {
            orderItem.Add();

            UpdateOrderInfo();

            return true;
        }

        public bool DeleteOrder(OrderItem orderItem)
        {
            orderItem.Delete();

            if (orderItem.Count == 0)
            {
                OrderItems.Remove(orderItem);
            }

            UpdateOrderInfo();

            return true;
        }

        protected void UpdateOrderInfo()
        {
            int total = 0;
            foreach (var order in OrderItems)
            {
                total += order.Price;
            }

            TotalPrice = total;

            OrderUpdated?.Invoke();
        }
    }
}

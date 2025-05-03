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
        
        public CompleteDelegate Complete { get; set; }

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


        public bool ExecutePay(enPayMedia media)
        {
            // 1. 5만원 이상 서명 패드

            // 2. 서명과 기타 거래 정보를 이용 결재 모듈 호출

            // 3. 결재완료된 후

            // 3-1. 영수증 출력

            // 3-2. 주방 영수증 출력

            // 4. 거래 정보 서버에 전달

            // 5. 처음 화면으로 이동

            return true;
        }
    }
}

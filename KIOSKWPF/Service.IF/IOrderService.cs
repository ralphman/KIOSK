using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKWPF.Service.IF
{
    internal interface IOrderService
    {
        int TotalPrice { get; }

        Action OrderUpdated { get; set; }

        ObservableCollection<OrderItem> OrderItems { get; }

        bool AddMenu(MenuItem menuItem);

        bool AddOrder(OrderItem orderItem);

        bool DeleteOrder(OrderItem orderItem);
    }
}

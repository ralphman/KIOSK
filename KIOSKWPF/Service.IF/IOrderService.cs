using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKWPF.Service.IF
{
    internal interface IOrderService : IOrderStep
    {
        //-------------- 주문 관련 사항 --------------//
        int TotalPrice { get; }

        Action OrderUpdated { get; set; }

        ObservableCollection<OrderItem> OrderItems { get; }

        bool AddMenu(MenuItem menuItem);

        bool AddOrder(OrderItem orderItem);

        bool DeleteOrder(OrderItem orderItem);

        //-------------- 결재 관련 사항 --------------//
        bool ExecutePay(enPayMedia media);
    }
}

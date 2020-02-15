using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
{
    public interface IOrderRepository
    {
        long CreateOrder(Order order);
        long CreateOrderInformation(OrderInformation orderInfor);
        List<Order> GetOrders();
        List<OrderStatus> GetStatuses();
        Order GetOrder(long id);
        List<OrderInformation> GetOrderInfors(long idOrder);
    }
}

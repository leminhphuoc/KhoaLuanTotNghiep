using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
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

using Models.Entity;
using Models.Model;
using System.Collections.Generic;


namespace FonNature.Services.IAdminServices
{
    public interface IOrderAdminServices
    {
        List<Order> GetOrders();
        List<OrderStatus> GetStatuses();
        Order GetOrder(long id);
        List<OrderInformation> GetOrderInfors(long idOrder);
        bool UpdateOrder(Order order, ShippingAddress shippingAddress);
    }
}

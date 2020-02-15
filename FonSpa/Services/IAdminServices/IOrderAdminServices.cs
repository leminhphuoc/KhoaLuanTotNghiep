using Models.Entity;
using System.Collections.Generic;


namespace FonNature.Services.IAdminServices
{
    public interface IOrderAdminServices
    {
        List<Order> GetOrders();
        List<OrderStatus> GetStatuses();
        List<Customer> GetCustomers();
        Order GetOrder(long id);
        List<OrderInformation> GetOrderInfors(long idOrder);
    }
}

using FonNature.Services.IAdminServices;
using Models.Entity;
using Models.Repository;
using System.Collections.Generic;

namespace FonNature.Services.AdminServices
{
    public class OrderAdminServices : IOrderAdminServices
    {
        private readonly OrdersRepository _orderRepository;
        private readonly CustomerAdminRepository _customerAdminRepository;
        public OrderAdminServices()
        {
            _orderRepository = OrdersRepository.getInstance();
            _customerAdminRepository = CustomerAdminRepository.getInstance();
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }
        public Order GetOrder(long id)
        {
            if (id == 0) return null;
            return _orderRepository.GetOrder(id);
        }


        public List<OrderStatus> GetStatuses()
        {
            return _orderRepository.GetStatuses();
        }

        public List<Customer> GetCustomers()
        {
            return _customerAdminRepository.GetListCustomer();
        }
        public List<OrderInformation> GetOrderInfors(long idOrder)
        {
            if (idOrder == 0) return new List<OrderInformation>();
            return _orderRepository.GetOrderInfors(idOrder);
        }
    }
}
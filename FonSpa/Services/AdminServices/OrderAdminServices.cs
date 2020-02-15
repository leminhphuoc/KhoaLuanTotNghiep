using FonNature.Services.IAdminServices;
using Models.Entity;
using Models.IRepository;
using System.Collections.Generic;

namespace FonNature.Services.AdminServices
{
    public class OrderAdminServices : IOrderAdminServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerAdminRepository _customerAdminRepository;
        public OrderAdminServices(IOrderRepository orderRepository, ICustomerAdminRepository customerAdminRepository)
        {
            _orderRepository = orderRepository;
            _customerAdminRepository = customerAdminRepository;
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
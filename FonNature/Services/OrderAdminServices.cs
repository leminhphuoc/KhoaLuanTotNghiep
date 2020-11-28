using FonNature.Services.Extension;
using FonNature.Services.IAdminServices;
using Models.Entity;
using Models.Model;
using Models.Repository;
using System.Collections.Generic;

namespace FonNature.Services.AdminServices
{
    public class OrderAdminServices : IOrderAdminServices
    {
        private readonly IOrderRepository _orderRepository;
        public OrderAdminServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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

        public List<OrderInformation> GetOrderInfors(long idOrder)
        {
            if (idOrder == 0) return new List<OrderInformation>();
            return _orderRepository.GetOrderInfors(idOrder);
        }

        public bool UpdateOrder(Order order, ShippingAddress shippingAddress)
        {
            if(order == null || shippingAddress == null)
            {
                return false;
            }

            order.ShippingAddress = shippingAddress.ParseToJson();
            return _orderRepository.UpdateOrder(order);
        }
    }
}
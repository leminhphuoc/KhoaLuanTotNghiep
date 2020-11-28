using FonNature.Services.Extension;
using Models.Entity;
using Models.Model;
using Models.Repository;
using System.Collections.Generic;

namespace FonNature.Services
{
    public class OrderService : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public long CreateOrder(List<ProductInCart> productInCarts, long clientAccountId, ShippingAddress shippingAddress)
        {
            try
            {
                var order = new Order() { ClientAccountId = clientAccountId , ShippingAddress = shippingAddress.ParseToJson() };
                var idOrder = _orderRepository.CreateOrder(order);
                foreach (var product in productInCarts)
                {
                    var orderInformation = new OrderInformation()
                    {
                        IdOrder = idOrder,
                        IdProduct = product.itemId,
                        Quantity = product.quantity
                    };
                    _orderRepository.CreateOrderInformation(orderInformation);
                }
                return idOrder;
            }
            catch
            {
                return 0;
            }
        }
    }
}
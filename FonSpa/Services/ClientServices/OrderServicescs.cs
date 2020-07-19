using FonNature.Services.IClientServices;
using Models.Entity;
using Models.Model;
using Models.Repository;
using System.Collections.Generic;

namespace FonNature.Services.ClientServices
{
    public class OrderServicescs : IOrderServices
    {
        private readonly OrdersRepository _orderRepository;
        private readonly CustomerAdminRepository _customerAdminRepository;
        public OrderServicescs()
        {
            _orderRepository = OrdersRepository.getInstance();
            _customerAdminRepository = CustomerAdminRepository.getInstance();
        }

        public long CreateOrder(List<ProductInCart> productInCarts, Customer customer)
        {
            try
            {
                var idCustomer = _customerAdminRepository.AddCustomer(customer);
                var order = new Order() { IdCustomer = idCustomer };
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
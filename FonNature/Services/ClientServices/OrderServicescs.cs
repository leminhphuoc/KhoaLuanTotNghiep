using FonNature.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
using Models.Model;
using System;
using System.Collections.Generic;

namespace FonNature.Services.ClientServices
{
    public class OrderServicescs : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerAdminRepository _customerAdminRepository;
        public OrderServicescs(IOrderRepository orderRepository, ICustomerAdminRepository customerAdminRepository)
        {
            _orderRepository = orderRepository;
            _customerAdminRepository = customerAdminRepository;
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
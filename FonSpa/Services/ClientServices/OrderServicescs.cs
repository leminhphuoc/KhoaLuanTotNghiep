using FonNature.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
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

        public long CreateOrder(List<OrderInformation> orderInformations, Customer customer)
        {
            var idCustomer = _customerAdminRepository.AddCustomer(customer);
            var order = new Order() { IdCustomer = idCustomer };
            var idOrder = _orderRepository.CreateOrder(order);
            foreach(var infor in orderInformations)
            {
                infor.IdOrder = idOrder;
                _orderRepository.CreateOrderInformation(infor);
            }
            return idOrder;
        }

    }
}
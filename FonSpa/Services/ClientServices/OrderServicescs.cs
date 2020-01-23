using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonNature.Services.ClientServices
{
    public class OrderServicescs
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
                _orderRepository.CreateOrderInformation(infor);
            }
            return idOrder;
        }

    }
}
using FonNature.Services.IServices;
using HelperLibrary;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonNature.Services.Services
{
    public class CustomerAdminServices : ICustomerAdminServices
    {
        private readonly ICustomerAdminRepository _customerAdminRepository;
        public CustomerAdminServices(ICustomerAdminRepository customerAdminRepository)
        {
            _customerAdminRepository = customerAdminRepository;
        }

        public List<Customer> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _customerAdminRepository.GetListCustomer();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var ListCustomer = _customerAdminRepository.ListSearchCustomer(searchString);
                return ListCustomer;
            }
        }

        public long AddCustomer(Customer customer)
        {
            if (customer == null) return 0;
            var addCustomer = _customerAdminRepository.AddCustomer(customer);
            var idCustomer = addCustomer;
            return idCustomer;
        }

        public Customer GetDetail(int id)
        {
            if (id == 0) return null;
            var customer = _customerAdminRepository.GetDetail(id);
            return customer;
        }

        public bool Edit(Customer customer)
        {
            if (customer == null) return false;
            var editCustomer = _customerAdminRepository.EditCustomer(customer);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _customerAdminRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus (int id)
        {
            var status = _customerAdminRepository.ChangeStatus(id);
            return status;
        }

    }
}
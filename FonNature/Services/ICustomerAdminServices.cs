using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services
{
    public interface ICustomerAdminServices
    {
        List<Customer> ListAllByName(string searchString);
        long AddCustomer(Customer customer);
        bool Delete(int id);
        Customer GetDetail(int id);
        bool Edit(Customer customer);
        bool? ChangeStatus(int id);
    }
}
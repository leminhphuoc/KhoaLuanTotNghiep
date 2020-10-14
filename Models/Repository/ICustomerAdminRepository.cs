using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface ICustomerAdminRepository
    {
        Customer GetDetail(long id);
        List<Customer> GetListCustomer();
        bool? ChangeStatus(long id);
        long AddCustomer(Customer customer);
        bool EditCustomer(Customer customer);
        bool Delete(long id);
        List<Customer> ListSearchCustomer(string searchString);
    }
}

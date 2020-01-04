using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
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

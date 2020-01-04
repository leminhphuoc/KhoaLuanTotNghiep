using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonNature.Services.IServices
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
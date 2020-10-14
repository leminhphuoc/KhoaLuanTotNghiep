using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repository
{
    public class CustomerAdminRepository : ICustomerAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public CustomerAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public Customer GetDetail(long id)
        {
            var customer = _db.Customers.Find(id);
            return customer;
        }

        public List<Customer> GetListCustomer()
        {
            return _db.Customers.ToList();
        }

        public long AddCustomer(Customer customer)
        {
            customer.status = true;
            customer.createdDate = DateTime.Now;
            var addCustomer = _db.Customers.Add(customer);
            _db.SaveChanges();
            return addCustomer.id;
        }

        public bool EditCustomer(Customer customer)
        {
            var customerEdit = _db.Customers.Where(x => x.id == customer.id).SingleOrDefault();
            customerEdit.Name = customer.Name;
            customerEdit.email = customer.email;
            customerEdit.phone = customer.phone;
            customerEdit.address = customer.address;
            customerEdit.token = customer.token;
            customerEdit.modifiedDate = DateTime.Now;
            customerEdit.status = customer.status;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var customer = _db.Customers.Find(id);
            if (customer != null)
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Customers.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public List<Customer> ListSearchCustomer(string searchString)
        {
            if (searchString == null) return null;

            var listCustomer = _db.Customers.Where(x => x.Name.ToUpper() == searchString.ToUpper());
            return listCustomer.ToList();
        }

        public int Count()
        {
            return _db.Customers.Count();
        }

        public int CountByMonth(int month)
        {
            return _db.Customers.Where(x => x.createdDate.Value.Month == month).Count();
        }
    }
}

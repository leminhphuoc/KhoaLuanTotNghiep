using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class OrdersRepository : IOrderRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public OrdersRepository()
        {
            _db = new FonNatureDbContext();
        }

        public long CreateOrder(Order order)
        {
            order.createdDate = DateTime.Now;
            var addOrder = _db.Orders.Add(order);
            _db.SaveChanges();
            return addOrder.Id;
        }
        public long CreateOrderInformation(OrderInformation orderInfor)
        {
            var addOrderInfor = _db.OrderInformations.Add(orderInfor);
            _db.SaveChanges();
            return addOrderInfor.Id;
        }
    }
}

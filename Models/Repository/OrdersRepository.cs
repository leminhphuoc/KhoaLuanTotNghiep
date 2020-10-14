using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (_db.OrderStatuses.ToList().Count != 0)
            {
                order.IdStatus = _db.OrderStatuses.Take(1).Select(x => x.Id).SingleOrDefault();
            }
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
        public List<Order> GetOrders()
        {
            return _db.Orders.OrderByDescending(x => x.createdDate).ToList();
        }

        public Order GetOrder(long id)
        {
            return _db.Orders.Where(x => x.Id == id).SingleOrDefault();
        }

        public List<OrderStatus> GetStatuses()
        {
            return _db.OrderStatuses.OrderBy(x => x.Id).ToList();
        }

        public List<OrderInformation> GetOrderInfors(long idOrder)
        {
            return _db.OrderInformations.Where(x => x.IdOrder == idOrder).ToList();
        }

    }
}

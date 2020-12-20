using log4net;
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

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

        public bool UpdateOrder(Order order)
        {
            try
            {
                var orderInDb = _db.Orders.Find(order.Id);
                if(orderInDb == null)
                {
                    return false;
                }

                orderInDb.ShippingAddress = order.ShippingAddress;
                orderInDb.IdStatus = order.IdStatus;
                _db.SaveChanges();

                log.Info($"Edit order success: {orderInDb.Id}");
                return true;
            }
            catch(Exception ex)
            {
                log.Error($"Error at Add Banner: {ex.Message}");
                return false;
            }
        }

        public bool UpdateOrderStatus(long orderId, int statusId)
        {
            try
            {
                var status = _db.Orders.Find(orderId);
                if (status == null)
                {
                    log.Warn($"Cannot find status: {orderId}");
                    return false;
                }

                status.IdStatus = statusId;
                _db.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                log.Error($"Cannot update status with id = {statusId} : {ex.Message}");
                return false;
            }
        }

        public void UpdatePrice(Order order, decimal subTotal, decimal discount)
        {
            try
            {
                var orderInDb = _db.Orders.Find(order.Id);
                if (orderInDb == null)
                {
                    return;
                }

                orderInDb.SubTotal = subTotal;
                orderInDb.Discount = discount;
                orderInDb.GrandTotal = subTotal - discount;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error($"Error at Update price: {ex.Message}");
                return;
            }
        }

        public List<OrderInformation> GetOrderInfors()
        {
            try
            {
                return _db.OrderInformations.ToList();
            }
            catch (Exception ex)
            {
                log.Error($"GetOrderInfors error: {ex.Message}");
                return new List<OrderInformation>();
            }
        }
    }
}

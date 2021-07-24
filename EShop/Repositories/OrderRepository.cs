using Eshop.DAL.Models;
using EShop.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EShop.DAL.Repositories
{
    class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EShopContext eShopContext) : base(eShopContext) { }

        public void AddOrder(Order order) 
            => _eShopContext.Set<Order>().Add(order);

        public void UpdateOrder(Order order) 
            => _eShopContext.Set<Order>().Update(order);

        public void DeleteOrder(Order order) 
            => _eShopContext.Set<Order>().Remove(order);

        public Order GetOrderById(int orderId) 
            => _eShopContext.Set<Order>().Where(x  => x.OrderId == orderId).FirstOrDefault();

        public List<Order> GetOrderByUserId(int userId)
            => _eShopContext.Set<Order>().ToList();
    }
}
using Eshop.DAL.Interfaces;
using Eshop.DAL.Models;
using System.Collections.Generic;

namespace EShop.DAL.Interfaces
{
    public interface IOrderRepository : IRepository<Order> 
    {
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        List<Order> GetOrderByUserId(int userId);
        Order GetOrderById(int orderId);
    }
}
using EShop.DAL.Interfaces;
using EShop.DAL.Models;

namespace EShop.DAL.Repositories
{
    class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EShopContext eShopContext) : base(eShopContext) { }
    }
}
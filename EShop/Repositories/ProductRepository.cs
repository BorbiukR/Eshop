using EShop.DAL.Interfaces;
using EShop.DAL.Models;

namespace EShop.DAL.Repositories
{
    class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EShopContext eShopContext) : base(eShopContext) { }
    }
}
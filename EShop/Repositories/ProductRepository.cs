using Eshop.DAL.Models;
using EShop.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EShop.DAL.Repositories
{
    class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EShopContext eShopContext) : base(eShopContext) { }

        public void AddProduct(Product product) 
            => _eShopContext.Set<Product>().Add(product);

        public void UpdateProduct(Product product) 
            => _eShopContext.Set<Product>().Update(product);
        
        public void DeleteProduct(Product product) 
            => _eShopContext.Set<Product>().Remove(product);
        
        public List<Product> GetAllProducts() 
            => _eShopContext.Set<Product>().ToList();

        public Product GetProductById(int prodId) 
            => _eShopContext.Set<Product>().Where(x => x.ProductId == prodId).FirstOrDefault();

        public Product GetProductByName(string productName) 
            => _eShopContext.Set<Product>().Where(x => x.Name == productName).FirstOrDefault();
    }
}
using Eshop.DAL.Interfaces;
using Eshop.DAL.Models;
using System.Collections.Generic;

namespace EShop.DAL.Interfaces
{
    public interface IProductRepository : IRepository<Product> 
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductByName(string productName);
        Product GetProductById(int prodId);            
    }
}
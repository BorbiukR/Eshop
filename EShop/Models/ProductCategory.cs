using Eshop.DAL.Models;

namespace EShop.DAL.Enums
{
    public class ProductCategory 
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
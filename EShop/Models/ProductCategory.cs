using Eshop.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace EShop.DAL.Enums
{
    public class ProductCategory 
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
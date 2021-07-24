using EShop.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace Eshop.DAL.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; }
    }
}

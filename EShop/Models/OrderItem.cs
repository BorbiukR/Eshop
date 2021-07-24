using Eshop.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace EShop.DAL.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
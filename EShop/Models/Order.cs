using EShop.DAL.Models.Enums;
using System.Collections.Generic;

namespace EShop.DAL.Models
{
    public class Order
    { 
        public int Id { get; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }   
}
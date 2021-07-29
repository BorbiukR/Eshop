using Eshop.DAL.Enums;
using EShop.DAL.Models;
using System.Collections.Generic;

namespace Eshop.DAL.Models
{
    public class Order
    {   // TODO: розібратися із модифікаторами доступу set
        public int OrderId { get; }
        public int UserId { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        
        public List<OrderItem> OrderItems { get; set; }
        public User User { get; set; }
    }   
}
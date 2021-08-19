using EShop.BL.DTOs.Enums;
using System.Collections.Generic;

namespace EShop.BL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public OrderStatusDTO Status { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }

        public UserDTO User { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }    
    }
}
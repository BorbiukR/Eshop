using EShop.BL.DTOs.Enums;
using System.Collections.Generic;

namespace EShop.BL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; }
        public OrderStatusDTO Status { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserDTOId { get; set; }

        public UserDTO UserDTO { get; set; }
        public List<OrderItemDTO> OrderItemsDTO { get; set; }    
    }
}
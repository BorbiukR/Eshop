using EShop.BL.DTOs.Enums;
using System.Collections.Generic;

namespace EShop.BL.DTOs
{
    public class OrderDTO
    {
        public int OrderDTOId { get; }
        public int UserDTOId { get; set; }
        public OrderStatusDTO Status { get; set; }
        public decimal TotalPrice { get; set; }

        public List<OrderItemDTO> OrderItemsDTO { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}
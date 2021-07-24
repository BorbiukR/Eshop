namespace EShop.BL.DTOs
{
    public class OrderItemDTO
    {
        public int OrderItemDTOId { get; set; }
        public ProductDTO ProductDTO { get; set; }
        public int Quantity { get; set; }
        public int OrderDTOId { get; set; }
        public OrderDTO OrderDTO { get; set; }
    }
}
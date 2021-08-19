namespace EShop.BL.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public OrderDTO Order { get; set; }
    }
}
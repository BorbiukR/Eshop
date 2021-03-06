namespace EShop.BL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public decimal Balance { get; set; }

        public OrderDTO Order { get; set; }
    }
}
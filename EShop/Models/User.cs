using System.ComponentModel.DataAnnotations;

namespace Eshop.DAL.Models
{
    public class User
    {
        [Key]
        public int UserId { get; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public decimal Balance { get; set; }

        public Order Order { get; set; }
    }
}
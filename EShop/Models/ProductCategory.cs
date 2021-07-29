namespace EShop.DAL.Models
{
    public class ProductCategory 
    {
        public int Id { get; }
        public string Name { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
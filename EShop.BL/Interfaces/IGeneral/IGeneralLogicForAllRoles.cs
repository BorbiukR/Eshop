using EShop.BL.DTOs;
using System.Collections.Generic;

namespace EShop.BL.Interfaces
{
    public interface IGeneralLogicForAllRoles
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductByName(string productName);
        ProductDTO GetProductById(int productId);      
    }
}
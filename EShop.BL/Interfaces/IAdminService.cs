using EShop.BL.DTOs;
using EShop.DAL.Models.Enums;

namespace EShop.BL.Interfaces
{
    public interface IAdminService 
    {
        string SeeUsersInfo();
        string SeeOrdersOfUser(int userId);
        string ChangeUserPassword(int userId, string newUserPassword);
        string AddProduct(string productName, decimal productPrice, string productDescription, ProductCategoryDTO productCategory);      
        string ModifyProduct(int productId, 
                            string newProductName = default, 
                            decimal newProductPrice = default, 
                            string newProductDescription = default, 
                            ProductCategoryDTO newProductCategory = default);
        string ChangeOrderStatus(int orderId, OrderStatus status);
    }
}
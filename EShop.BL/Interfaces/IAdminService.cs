using EShop.BL.DTOs;
using EShop.DAL.Models.Enums;

namespace EShop.BL.Interfaces
{
    public interface IAdminService
    {
        string SeeUsersInfo();
        string SeeOrdersOfUser(int userId);
        string ChangeUserPassword(int userId, string newUserPassword);
        string AddProduct(ProductDTO product);
        string ModifyProduct(ProductDTO product);
        string ChangeOrderStatus(int orderId, OrderStatus status);
    }
}
using EShop.BL.DTOs;
using System.Collections.Generic;

namespace EShop.BL.Interfaces
{
    public interface IUserService : IGeneralLogicForUserAndAdmin
    {
        List<OrderDTO> SeeOrderHistory(int userId);
        string SetStatusReceived(int userId);
        string ChangePassword(int userId, string oldPassword, string newPassword);
    }
}
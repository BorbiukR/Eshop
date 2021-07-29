using EShop.BL.DTOs;

namespace EShop.BL.Interfaces
{
    public interface IGeneralLogicForUserAndAdmin
    {
        string AddToOrder(string productName, OrderDTO orderDTO);
        string CancelOrder(int userId);

        delegate void LogOutHendler();
        event LogOutHendler NotifyOfLoggingOut;
        string LogOut();
    }
}
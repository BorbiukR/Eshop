namespace EShop.BL.Interfaces
{
    public interface IGeneralLogicForUserAndAdmin
    {
        string AddToOrder(string name);

        string CancelOrder(int userIdId);

        delegate void LogOutHendler();
        event LogOutHendler NotifyOfLoggingOut;
        string LogOut();
    }
}
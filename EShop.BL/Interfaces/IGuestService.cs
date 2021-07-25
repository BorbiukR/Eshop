using EShop.BL.DTOs;

namespace EShop.BL.Interfaces
{
    public interface IGuestService : IGeneralLogicForAllRoles
    {
        delegate void LogInHendler(UserDTO user);
        event LogInHendler NotifyOfLogginIn;

        string LogIn(string email, string password);
        string Register(string email, string password, string confirmPassword);
    }
}
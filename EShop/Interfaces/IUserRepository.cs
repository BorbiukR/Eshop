using Eshop.DAL.Interfaces;
using Eshop.DAL.Models;
using System.Collections.Generic;

namespace EShop.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User> 
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int userId);
        User GetUserByEmail(string email);        
    }
}
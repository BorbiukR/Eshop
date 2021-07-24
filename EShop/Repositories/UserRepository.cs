using Eshop.DAL.Models;
using EShop.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EShop.DAL.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EShopContext eShopContext) : base(eShopContext) { }

        public void AddUser(User user) =>
            _eShopContext.Set<User>().Add(user);
        
        public void UpdateUser(User user)
            => _eShopContext.Set<User>().Update(user);

        public void DeleteUser(User user)
            => _eShopContext.Set<User>().Remove(user);

        public List<User> GetAllUsers()
            => _eShopContext.Set<User>().ToList();

        public User GetUserByEmail(string email)
            => (User)_eShopContext.Set<User>().Where(x => x.Email == email);

        public User GetUserById(int userId)
            => (User)_eShopContext.Set<User>().Where(x => x.UserId == userId);
    }
}
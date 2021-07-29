using EShop.DAL.Interfaces;
using EShop.DAL.Models;

namespace EShop.DAL.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EShopContext eShopContext) : base(eShopContext) { }      
    }
}
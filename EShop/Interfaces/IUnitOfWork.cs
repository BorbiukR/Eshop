using EShop.DAL.Interfaces;

namespace Eshop.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        void Save();
    }
}
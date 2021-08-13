using EShop.DAL.Interfaces;
using System.Threading.Tasks;

namespace Eshop.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        IProductRepository Products { get; }

        IOrderRepository Orders { get; }

        Task<int> SaveAsync();
    }
}
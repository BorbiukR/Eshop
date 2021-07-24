using DAL.Interfaces;
using EShop.DAL;
using EShop.DAL.Interfaces;
using EShop.DAL.Repositories;

namespace DAL.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EShopContext _eShopContext;
        private IUserRepository _users;
        private IProductRepository _products;
        private IOrderRepository _orders;

        public UnitOfWork(EShopContext context)
        {
            _eShopContext = context;
        }

        public void Save() => _eShopContext.SaveChanges();
        
        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_eShopContext);
                }
                return _users;
            }
        }

        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(_eShopContext);
                }
                return _products;
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new OrderRepository(_eShopContext);
                }
                return _orders;
            }
        }
    }
}
using Eshop.DAL.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EShop.DAL.Repositories
{ 
    abstract class Repository<T> : IRepository<T> where T : class
    {
        protected internal readonly EShopContext _eShopContext;

        public Repository(EShopContext context)
        {
            _eShopContext = context;
        }

        public async Task AddAsync(T entity) => await _eShopContext.Set<T>().AddAsync(entity);

        public void Update(T entity) => _eShopContext.Set<T>().Update(entity);

        public void Delete(T entity) => _eShopContext.Set<T>().Remove(entity);
        
        public IQueryable<T> FindAll() => _eShopContext.Set<T>();
        
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _eShopContext.Set<T>().Where(expression);             
    }
}
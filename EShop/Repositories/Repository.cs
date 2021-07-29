using Eshop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EShop.DAL.Repositories
{ 
    abstract class Repository<T> : IRepository<T> where T : class
    {
        protected internal readonly EShopContext _eShopContext;

        public Repository(EShopContext context)
        {
            _eShopContext = context;
        }

        public void Add(T entity) => _eShopContext.Set<T>().Add(entity);

        public void Update(T entity) => _eShopContext.Set<T>().Update(entity);

        public void Delete(T entity) => _eShopContext.Set<T>().Remove(entity);
        
        public IEnumerable<T> FindAll() => _eShopContext.Set<T>().ToList();
        
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _eShopContext.Set<T>().Where(expression).ToList();             
    }
}
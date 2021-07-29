using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Eshop.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    { // можна у всіх інших репозиторіях стерти логіку , але тоді прийдеться робити LINQ для Get запросів
      // або стерти лише логіку Add Update Delate
        void Create(T value);
        void Update(T value);
        void Delete(T value);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}

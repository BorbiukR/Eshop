using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Eshop.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    { 
        void Add(T value);
        void Update(T value);
        void Delete(T value);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
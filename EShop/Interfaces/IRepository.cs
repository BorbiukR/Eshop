using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Eshop.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T value);

        void Update(T value);

        void Delete(T value);

        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
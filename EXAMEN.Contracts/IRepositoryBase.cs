using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    }
}

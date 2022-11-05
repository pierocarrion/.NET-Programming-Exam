using EXAMEN.Entities.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;

namespace EXAMEN.Contracts.Implementation
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DbSet<T> dbSet;
        protected DBContext _context;
        protected ILoggerManager _logger;

        public RepositoryBase(DBContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            _logger.LogInfo($"{typeof(T)}");

            return await dbSet.Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            _logger.LogInfo($"{typeof(T)}");

            return dbSet;
        }

        public virtual async Task<T> GetById(int id)
        {
            _logger.LogInfo($"{typeof(T)} - ID : {id}");

            return await dbSet.FindAsync(id);
        }

        public virtual async Task Create(T entity)
        {
            _logger.LogInfo($"{typeof(T)}");

            dbSet.Add(entity);
        }

        public virtual async Task Delete(T entity)
        {
            _logger.LogInfo($"{typeof(T)} - Deleted : {JsonSerializer.Serialize(entity)}");

            dbSet.Remove(entity);
        }

        public virtual async Task Update(T entity)
        {
            _logger.LogInfo($"Update - Not implemented Function - {typeof(T)}");
            
            //Implemented in each Repository Children
            throw new NotImplementedException();
        }
    }
}

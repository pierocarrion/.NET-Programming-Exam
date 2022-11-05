

using EXAMEN.Contracts;
using EXAMEN.Contracts.Implementation;
using EXAMEN.Contracts.Repositories;
using EXAMEN.Entities;
using EXAMEN.Entities.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Json;

namespace EXAMEN.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(DBContext context, ILoggerManager logger) : base(context,logger)
        {
        }

        public override async Task<IEnumerable<Order>> Find(Expression<Func<Order, bool>> expression)
        {
            _logger.LogInfo($"{typeof(Order)}");

            return await dbSet.Where(expression).Include(x=>x.Customer).ToListAsync();
        }
        
        public override async Task Update(Order entity)
        {
            _logger.LogInfo($"{typeof(Order)}");
            
            var orderToUpdate = dbSet.Find(entity.OrderId);

            if(orderToUpdate is not null)
            {
                orderToUpdate.Confirmed = entity.Confirmed;
                orderToUpdate.ConfirmationDate = entity.ConfirmationDate;
                orderToUpdate.Comments = entity.Comments;
            }
            else
            {
                _logger.LogInfo($"{JsonSerializer.Serialize(entity)} Not found");
            }
        }
    }
}
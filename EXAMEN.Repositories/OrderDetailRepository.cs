using EXAMEN.Contracts;
using EXAMEN.Contracts.Implementation;
using EXAMEN.Contracts.Repositories;
using EXAMEN.Entities;
using EXAMEN.Entities.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EXAMEN.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DBContext context, ILoggerManager logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<OrderDetail>> Find(Expression<Func<OrderDetail, bool>> expression)
        {
            _logger.LogInfo($"{typeof(OrderDetail)}");

            return await dbSet.Where(expression).Include(x => x.Product).ToListAsync();
        }
    }
}

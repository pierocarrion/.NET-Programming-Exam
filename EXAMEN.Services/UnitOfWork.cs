

using EXAMEN.Contracts;
using EXAMEN.Contracts.Repositories;
using EXAMEN.Entities.Data;
using EXAMEN.Repositories;

namespace EXAMEN.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContext _context;
        public IOrderRepository Order { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }

        public UnitOfWork(DBContext context, ILoggerManager logger)
        {
            _context = context;

            Order = new OrderRepository(context,logger);
            OrderDetail = new OrderDetailRepository(context, logger);
        }

        public async Task<bool> CompleteAsync()
        {
            return (await _context.SaveChangesAsync() >= 0); // 1 = Successful | 0 = Failed
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using EXAMEN.Contracts.Repositories;

namespace EXAMEN.Services
{
    public interface IUnitOfWork
    {
        IOrderRepository Order { get; }
        IOrderDetailRepository OrderDetail { get; }

        Task<bool> CompleteAsync();
        void Dispose();
    }
}

using EXAMEN.Models.ViewModels.OrderDetail;

namespace EXAMEN.Models.ViewModels.Order
{
    public partial class OrderViewModelDetail
    {
        public int OrderId { get; set; }
        public string ContactName { get; set; }
        public IEnumerable<OrderDetailViewModelShort> OrderDetails { get; set; }
    }
}

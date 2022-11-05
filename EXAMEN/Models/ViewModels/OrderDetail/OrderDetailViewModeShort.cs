namespace EXAMEN.Models.ViewModels.OrderDetail
{
    public partial class OrderDetailViewModelShort
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string OrderDetailId => $"{OrderId}-{ProductId}";
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public float Discount { get; set; }
        public short Quantity { get; set; }
        public float Total => (float)(Quantity * UnitPrice);
    }
}
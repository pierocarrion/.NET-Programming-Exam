using System.ComponentModel.DataAnnotations;

namespace EXAMEN.Models.ViewModels.Order
{
    public partial class OrderViewModel
    {
        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public bool? Confirmed { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string Comments { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
    }
}
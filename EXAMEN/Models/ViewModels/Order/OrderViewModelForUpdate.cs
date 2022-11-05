using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EXAMEN.Models.ViewModels.Order
{
    public partial class OrderViewModelForUpdate
    {
        public int OrderId { get; set; }

        [Required]
        [Display(Name ="Confirmado")]
        public bool Confirmed { get; set; }
        
        [Required]
        public DateTime? ConfirmationDate { get; set; } = DateTime.Now;
        
        [Required]
        [Display(Name = "Comentario")]
        public string Comments { get; set; }
    }
}

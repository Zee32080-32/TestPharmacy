using PharmacyApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyApp.ViewModels
{
    public class PaymentViewModel
    {

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customers Customer { get; set; } 

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentStatus { get; set; }
    }
}

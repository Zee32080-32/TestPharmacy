using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmacyApp.Models
{
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int PrescriptionOrderId { get; set; }

        [ForeignKey("PrescriptionOrderId")]
        public PrescriptionOrders PrescriptionOrder { get; set; } 

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

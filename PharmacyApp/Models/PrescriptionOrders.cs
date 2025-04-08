using System.Diagnostics;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyApp.Models
{
    public class PrescriptionOrders
    {

        [Key]
        [Required]
        public int PrescriptionOrderId { get; set; }

        [Required]
        public int CustomerId { get; set; } // Changed to match FK in Customers

        [ForeignKey("CustomerId")]
        public Customers Customer { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentStatus { get; set; }
    }
}

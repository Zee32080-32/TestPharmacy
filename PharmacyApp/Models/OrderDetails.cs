using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmacyApp.Models
{
    public class OrderDetails
    {
        [Key]
        [Required]
        public int OrderDetailId { get; set; }

        [Required]
        public int PrescriptionOrderId { get; set; }

        [ForeignKey("PrescriptionOrderId")]
        public PrescriptionOrders PrescriptionOrder { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Products Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}

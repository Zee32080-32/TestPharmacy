using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyApp.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public int cartId { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        [ForeignKey("productId")]
        public Products Product { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [ForeignKey("CustomerId")]
        public Customers Customer { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] 
        public decimal TotalPrice { get; set; }

    }
}

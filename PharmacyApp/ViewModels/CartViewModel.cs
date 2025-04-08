using PharmacyApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmacyApp.ViewModels
{
    public class CartViewModel
    {

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

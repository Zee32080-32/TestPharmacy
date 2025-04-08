using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmacyApp.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        [Required]
        public string ProductPicUrl { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public CustomerViewModel Customer { get; set; }

    }
}

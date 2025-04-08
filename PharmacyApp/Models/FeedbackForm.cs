using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyApp.Models
{
    public class FeedbackForm
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string CustomerID { get; set; }

        [ForeignKey(nameof(CustomerID))]
        public IdentityUser customers { get; set; }
    }
}

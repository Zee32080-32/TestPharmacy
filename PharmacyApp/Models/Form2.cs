using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyApp.Models
{
    public class Form2
    {
        [Required]
        [Key]
        public int id  { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public DateTime datecreated = DateTime.Now;
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [ForeignKey(nameof(CustomerId))]
        public Customers Customer { get; set; }
    }
}

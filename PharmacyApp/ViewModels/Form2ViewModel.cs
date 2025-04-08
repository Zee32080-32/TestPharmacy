using PharmacyApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmacyApp.ViewModels
{
    public class Form2ViewModel
    {
        [Required]
        public int id { get; set; }
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

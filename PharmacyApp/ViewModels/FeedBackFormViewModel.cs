using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmacyApp.ViewModels
{
    public class FeedBackFormViewModel
    {
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }


    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ContactsHillaker.Models
{
    public class Contact
    {
        //Name (string)
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Your name can only contain letters and spaces.")]
        public string Name { get; set; } = string.Empty;

        // Phone number (string)
        [Required(ErrorMessage = "Please enter a phone number.")]
        [RegularExpression(@"^\+?[0-9 ]{6,14}[0-9]$", ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }

        // Address (string)
        [Required(ErrorMessage = "Please enter an address.")]
        public string Address { get; set; }

        // Notes
        [ValidateNever]
        public string Notes { get; set; } = null!;

        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Phone?.ToString();

    }
}

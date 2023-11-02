using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ToDoListHillaker.Models;

namespace ToDoListHillaker.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }

        [Required(ErrorMessage = "Please enter a Name.")]
        [StringLength(30, ErrorMessage = "Name must be 30 characters or less.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Description.")]
        [StringLength(200, ErrorMessage = "Description must be 200 characters or less.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Sprint Number.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Sprint Number must be a whole number")]
        public string SprintNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a Point Value.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Point Value must be a whole number")]
        public string PointValue { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a Status.")]
        public string StatusID { get; set; } = string.Empty;

        [ValidateNever]
        public Status Status { get; set; } = null!;

    }
}
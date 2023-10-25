using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ToDoListHillaker.Models;

namespace ToDoListHillaker.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }

        [Required(ErrorMessage = "Please enter a Name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Description.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Sprint Number.")]
        public string SprintNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a Point Value.")]
        public string PointValue { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a Status.")]
        public string StatusID { get; set; } = string.Empty;

        [ValidateNever]
        public Status Status { get; set; } = null!;

    }
}
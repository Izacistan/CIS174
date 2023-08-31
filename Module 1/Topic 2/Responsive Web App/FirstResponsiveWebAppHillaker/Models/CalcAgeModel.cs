using System.ComponentModel.DataAnnotations;

namespace FirstResponsiveWebAppHillaker.Models
{
    public class CalcAgeModel
    {
        [Required(ErrorMessage = "You must type in your name!")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Your name can only be letters!.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "You must enter your birth year!")]
        [Range(1900, 2100, ErrorMessage = "Please enter a valid birth year between 1900 and 2100.")]
        public int? BirthYear { get; set; }

        public int? Age { get; set; }

        public int? CalcAge() 
        {
            // Get the current year
            int currentYear = DateTime.Now.Year;
            // Get the user's birth year
            int? birthYear = BirthYear;
            // Calculate age
            int? age = currentYear - birthYear;
            // If the birthday hasn't occurred yet this year, subtract 1 from the age
            if (DateTime.Now < new DateTime(currentYear, 12, 31))
            {
                age--;
            }
            return age;
        }
    }
}

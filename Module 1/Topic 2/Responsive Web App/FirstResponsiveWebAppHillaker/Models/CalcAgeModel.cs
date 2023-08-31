namespace FirstResponsiveWebAppHillaker.Models
{
    public class CalcAgeModel
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public int Age { get; set; }

        public int CalcAge() 
        {
            // Get the current year
            int currentYear = DateTime.Now.Year;
            // Get the user's birth year
            int birthYear = BirthYear;
            // Calculate age
            int age = currentYear - birthYear;
            // If the birthday hasn't occurred yet this year, subtract 1 from the age
            if (DateTime.Now < new DateTime(currentYear, 12, 31))
            {
                age--;
            }
            return age;
        }
    }
}

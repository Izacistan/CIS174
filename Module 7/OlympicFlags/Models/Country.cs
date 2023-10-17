namespace OlympicFlags.Models
{
    public class Country
    {
        public string CountryID { get; set; }
        public string CountryName { get; set; }
        public Games Game { get; set; }
        public Category Category { get; set; }
        public string CountryFlag { get; set; }

    }
}

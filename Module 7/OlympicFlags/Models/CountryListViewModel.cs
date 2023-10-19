namespace OlympicFlags.Models
{
    public class CountryListViewModel : CountryViewModel
    {
        public String UserName { get; set; }
        public List<Country> Countries { get; set; }

        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = new List<Category> {
                    new Category { CategoryID = "all", CategoryName = "All" }
                };
                categories.AddRange(value);
            }
        }

        private List<Games> games;
        public List<Games> Games
        {
            get => games;
            set
            {
                games = new List<Games> {
                    new Games { GamesID = "all", GamesName = "All" }
                };
                games.AddRange(value);
            }
        }

        // methods to help view determine active link
        public string CheckActiveCategory(string c) =>
            c.ToLower() == ActiveCategory.ToLower() ? "active" : "";
        public string CheckActiveGame(string d) =>
            d.ToLower() == ActiveGame.ToLower() ? "active" : "";

    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

using OlympicFlags.Models;

namespace OlympicFlags.Models
{
    public class OlympicSession
    {

        private const string CountryKey = "myCountries";
        private const string CountKey = "countryCount";
        private const string CategoryKey = "category";
        private const string GameKey = "game";
        private const string NameKey = "name";

        private ISession session { get; set; }
        public OlympicSession(ISession session)
        {
            this.session = session;
        }

        public void SetMyCountries(List<Country> countries)
        {
            session.SetObject(CountryKey, countries);
            session.SetInt32(CountKey, countries.Count);
        }
        public List<Country> GetMyCountries() =>
            session.GetObject<List<Country>>(CountryKey) ?? new List<Country>();
        public int? GetMyCountryCount() => session.GetInt32(CountKey);

        public void SetName(string userName = "friend")
        {
            session.SetString(NameKey, userName);
        }
        public string GetName() => session.GetString(NameKey);

        public void SetActiveCategory(string category) =>
            session.SetString(CategoryKey, category);
        public string GetActiveCategory() => session.GetString(CategoryKey);

        public void SetActiveGames(string games) =>
            session.SetString(GameKey, games);
        public string GetActiveGames() => session.GetString(GameKey);

        public void RemoveMyCountries()
        {
            session.Remove(CountryKey);
            session.Remove(CountKey);
        }
    }
}

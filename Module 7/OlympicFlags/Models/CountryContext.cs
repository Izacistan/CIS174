using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OlympicFlags.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options)
            : base(options)
        { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Games> Game { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = "indoor", CategoryName = "Indoor" },
                new Category { CategoryID = "outdoor", CategoryName = "Outdoor" }
            );
            modelBuilder.Entity<Games>().HasData(
                new Games { GamesID = "summer", GamesName = "Summer Olympics" },
                new Games { GamesID = "winter", GamesName = "Winter Olympics" },
                new Games { GamesID = "paralympic", GamesName = "Paralympic Games" },
                new Games { GamesID = "youth", GamesName = "Youth Olympic Games" }
            );
            modelBuilder.Entity<Country>().HasData(
                new { CountryID = "can", CountryName = "Canada", CategoryID = "indoor", GamesID = "winter", CountryFlag = "canada.jpg" },
                new { CountryID = "swe", CountryName = "Sweden", CategoryID = "indoor", GamesID = "winter", CountryFlag = "sweden.jpg" },
                new { CountryID = "gbr", CountryName = "Great Britain", CategoryID = "indoor", GamesID = "winter", CountryFlag = "great_britain.jpg" },
                new { CountryID = "jam", CountryName = "Jamaica", CategoryID = "outdoor", GamesID = "winter", CountryFlag = "jamaica.jpg" },
                new { CountryID = "ita", CountryName = "Italy", CategoryID = "outdoor", GamesID = "winter", CountryFlag = "italy.jpg" },
                new { CountryID = "jpn", CountryName = "Japan", CategoryID = "outdoor", GamesID = "winter", CountryFlag = "japan.jpg" },
                new { CountryID = "deu", CountryName = "Germany", CategoryID = "indoor", GamesID = "summer", CountryFlag = "germany.jpg" },
                new { CountryID = "chn", CountryName = "China", CategoryID = "indoor", GamesID = "summer", CountryFlag = "china.jpg" },
                new { CountryID = "mex", CountryName = "Mexico", CategoryID = "indoor", GamesID = "summer", CountryFlag = "mexico.jpg" },
                new { CountryID = "bra", CountryName = "Brazil", CategoryID = "outdoor", GamesID = "summer", CountryFlag = "brazil.jpg" },
                new { CountryID = "abw", CountryName = "Netherlands", CategoryID = "outdoor", GamesID = "summer", CountryFlag = "netherlands.jpg" },
                new { CountryID = "usa", CountryName = "United States", CategoryID = "outdoor", GamesID = "summer", CountryFlag = "united_states.jpg" },
                new { CountryID = "tha", CountryName = "Thailand", CategoryID = "indoor", GamesID = "paralympic", CountryFlag = "thailand.jpg" },
                new { CountryID = "ury", CountryName = "Uruguay", CategoryID = "indoor", GamesID = "paralympic", CountryFlag = "uruguay.jpg" },
                new { CountryID = "ukr", CountryName = "Ukraine", CategoryID = "indoor", GamesID = "paralympic", CountryFlag = "ukraine.jpg" },
                new { CountryID = "aut", CountryName = "Austria", CategoryID = "outdoor", GamesID = "paralympic", CountryFlag = "austria.jpg" },
                new { CountryID = "pak", CountryName = "Pakistan", CategoryID = "outdoor", GamesID = "paralympic", CountryFlag = "pakistan.jpg" },
                new { CountryID = "zwe", CountryName = "Zimbabwe", CategoryID = "outdoor", GamesID = "paralympic", CountryFlag = "zimbabwe.jpg" },
                new { CountryID = "fra", CountryName = "France", CategoryID = "indoor", GamesID = "youth", CountryFlag = "france.jpg" },
                new { CountryID = "cyp", CountryName = "Cyrpus", CategoryID = "indoor", GamesID = "youth", CountryFlag = "cyprus.jpg" },
                new { CountryID = "rus", CountryName = "Russia", CategoryID = "indoor", GamesID = "youth", CountryFlag = "russia.jpg" },
                new { CountryID = "fin", CountryName = "Finland", CategoryID = "outdoor", GamesID = "youth", CountryFlag = "finland.jpg" },
                new { CountryID = "svk", CountryName = "Slovakia", CategoryID = "outdoor", GamesID = "youth", CountryFlag = "slovakia.jpg" },
                new { CountryID = "prt", CountryName = "Portugal", CategoryID = "outdoor", GamesID = "youth", CountryFlag = "portugal.jpg" }
            );
        }
    }
}

using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace ContactsHillaker.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        { }
        public DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    Name = "Alice",
                    Phone = "5152316759",
                    Address = "1234 Sesame Street. New York City, New York, USA",
                    Notes = "These are some notes on this person."
                },
                new Contact
                {
                    ContactId = 2,
                    Name = "Bob",
                    Phone = "5152316759",
                    Address = "1234 Sesame Street. New York City, New York, USA",
                    Notes = "These are some notes on this person."
                },
                new Contact
                {
                    ContactId = 3,
                    Name = "Candace",
                    Phone = "5152316759",
                    Address = "1234 Sesame Street. New York City, New York, USA",
                    Notes = "These are some notes on this person."
                }
            );
        }
    }
}

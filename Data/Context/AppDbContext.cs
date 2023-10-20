using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using UsersNotebook.Data.Entities;

namespace UsersNotebook.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    DataUrodzenia = new DateTime(1990, 1, 1),
                    Płeć = "Mężczyzna",
                    DodatkoweParametry = JsonSerializer.Serialize(new List<AdditionalParameters>
                    {
                        new AdditionalParameters{ Key = "Numer Telefonu", Value = "123-456-789" },
                        new AdditionalParameters{ Key = "Stanowisko", Value = "Programista" }
                    })
                },
                new User
                {
                    Id = 2,
                    Imie = "Anna",
                    Nazwisko = "Nowak",
                    DataUrodzenia = new DateTime(1995, 5, 5),
                    Płeć = "Kobieta",
                    DodatkoweParametry = JsonSerializer.Serialize(new List<AdditionalParameters>
                    {
                        new AdditionalParameters{ Key = "Numer Telefonu", Value = "123-456-789" },
                        new AdditionalParameters{ Key = "Stanowisko", Value = "Analityk" }
                    })
                });
        }
    }
}

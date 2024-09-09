using BankingControlPanel.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingControlPanel
{    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Address entities first
            var address1 = new Address
            {
                Id = 1,
                Country = "USA",
                City = "New York",
                Street = "123 Main St",
                ZipCode = "10001"
            };

            var address2 = new Address
            {
                Id = 2,
                Country = "USA",
                City = "Los Angeles",
                Street = "456 Elm St",
                ZipCode = "90001"
            };

            modelBuilder.Entity<Address>().HasData(address1, address2);

            // Seed Client entities using the generated Address Id values
            var client1 = new Client
            {
                Id = 1,
                Email = "client1@example.com",
                FirstName = "John",
                LastName = "Doe",
                PersonalId = "12345678901",
                MobileNumber = "+1 555-1234",
                Sex = "Male",
                AddressId = address1.Id,
                ProfilePhoto = "client1.jpg" // Provide a valid value
            };

            var client2 = new Client
            {
                Id = 2,
                Email = "client2@example.com",
                FirstName = "Jane",
                LastName = "Smith",
                PersonalId = "98765432101",
                MobileNumber = "+1 555-5678",
                Sex = "Female",
                AddressId = address2.Id,
                ProfilePhoto = "client2.jpg" // Provide a valid value
            };

            modelBuilder.Entity<Client>().HasData(client1, client2);
        }
    }
}

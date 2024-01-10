using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WalletApp.DAL.Configurations;
using WalletApp.DAL.Models;
using WalletApp.DTO.Enums;

namespace WalletApp.DAL
{
    public class WalletAppEntities : DbContext, IWalletAppEntities
    {
        public WalletAppEntities(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<CardBalance> CardBalances { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddConfiguration(modelBuilder);

            base.OnModelCreating(modelBuilder);

            //Для теста
            GenerateUsers(modelBuilder);
            GenerateCardBalance(modelBuilder);
            GenerateTransactions(modelBuilder);
        }

        private void AddConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CardBalanceConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }

        private void GenerateUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User { Id = 1, Login = "Admin", Password = "pass" },
               new User { Id = 2, Login = "Ann", Password = "pass2" }
            );
        }

        private void GenerateCardBalance(ModelBuilder modelBuilder)
        {
            var rand = new Random();
            modelBuilder.Entity<CardBalance>().HasData(
               new CardBalance { Id = 1, Limit = 1500, Balance = rand.Next(0, 1500), UserId = 1 }
            );
        }

        private void GenerateTransactions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(
               new Transaction 
               { 
                   Id = 1, 
                   UserId = 1, 
                   CardBalanceId = 1, 
                   Description = "Текст",
                   IconPath = "path",
                   Name = "IKEA",
                   Pending = true,
                   Sum = 24.5f,
                   Type = TransactionType.Payment,
                   Date = new DateTime(2024, 1, 1, 0, 0, 0)
               },
               new Transaction
               {
                   Id = 2,
                   UserId = 1,
                   CardBalanceId = 1,
                   Description = "Текст",
                   IconPath = "path",
                   Name = "IKEA",
                   Pending = true,
                   Sum = 24.5f,
                   Type = TransactionType.Payment,
                   Date = new DateTime(2024, 1, 2, 0, 0, 0)
               },
               new Transaction
               {
                   Id = 3,
                   UserId = 1,
                   CardBalanceId = 1,
                   Description = "Текст",
                   IconPath = "path",
                   Name = "IKEA",
                   Pending = true,
                   Sum = 24.5f,
                   Type = TransactionType.Credit,
                   Date = new DateTime(2024, 1, 3, 0, 0, 0)
               },
               new Transaction
               {
                   Id = 4,
                   UserId = 1,
                   CardBalanceId = 1,
                   Description = "Текст",
                   IconPath = "path",
                   Name = "IKEA",
                   Pending = true,
                   Sum = 24.5f,
                   Type = TransactionType.Payment,
                   Date = new DateTime(2024, 1, 4, 0, 0, 0)
               },
               new Transaction
               {
                   Id = 5,
                   UserId = 1,
                   CardBalanceId = 1,
                   Description = "Текст",
                   IconPath = "path",
                   Name = "IKEA",
                   Pending = false,
                   Sum = 24.5f,
                   Type = TransactionType.Credit,
                   Date = new DateTime(2024, 1, 5, 0, 0, 0)
               },
               new Transaction
               {
                   Id = 6,
                   UserId = 2,
                   CardBalanceId = 1,
                   Description = "Текст",
                   IconPath = "path",
                   Name = "IKEA",
                   Pending = true,
                   Sum = 24.5f,
                   Type = TransactionType.Payment,
                   Date = new DateTime(2024, 1, 6, 0, 0, 0)
               },
               new Transaction
               {
                   Id = 7,
                   UserId = 1,
                   CardBalanceId = 1,
                   Description = "Текст",
                   IconPath = "path",
                   Name = "IKEA",
                   Pending = true,
                   Sum = 24.5f,
                   Type = TransactionType.Payment,
                   Date = new DateTime(2024, 1, 7, 0, 0, 0)
               },
               new Transaction
               {
                   Id = 8,
                   UserId = 1,
                   CardBalanceId = 1,
                   Description = "Текст",
                   IconPath = "path",
                   Name = "IKEA",
                   Pending = true,
                   Sum = 24.5f,
                   Type = TransactionType.Payment,
                   Date = new DateTime(2024, 1, 8, 0, 0, 0)
               },
               new Transaction
               {
                   Id = 9,
                   UserId = 1,
                   CardBalanceId = 1,
                   Description = "Текст",
                   IconPath = "path",
                   Name = "IKEA",
                   Pending = false,
                   Sum = 27.5f,
                   Type = TransactionType.Payment,
                   Date = new DateTime(2024, 1, 9, 0, 0, 0)
               },
               new Transaction
               {
                   Id = 10,
                   UserId = 1,
                   CardBalanceId = 1,
                   Description = "Текст",
                   IconPath = "path",
                   Name = "IKEA",
                   Pending = true,
                   Sum = 24.5f,
                   Type = TransactionType.Payment,
                   Date = new DateTime(2023, 10, 8, 0, 0, 0)
               },
               new Transaction
               {
                   Id = 11,
                   UserId = 2,
                   CardBalanceId = 1,
                   Description = "Текст",
                   IconPath = "path",
                   Name = "IKEA",
                   Pending = true,
                   Sum = 24.5f,
                   Type = TransactionType.Payment,
                   Date = new DateTime(2023, 10, 10, 0, 0, 0)
               }
            );
        }
    }
}

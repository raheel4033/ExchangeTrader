using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasData(
                new Product { productID = 1, Symbol = "AAPL", lotSize = 100, tickSize = 0.01m, Description = "Apple Inc. Common Stock",qouteCurrency="USD",settleCurrency="PKR" },
                new Product { productID = 2, Symbol = "GOOGL", lotSize = 100, tickSize = 0.05m, Description = "Google LLC Class C Capital Stock", qouteCurrency = "INR", settleCurrency = "USD" }
            );
            modelBuilder.Entity<Order>()
           .HasData(
               new Order
               {
                   OrderId = 1,
                   productID = 1,
                   price = 15000,
                   quantity = 200,
                   side = "Buy",
                   orderStatus = "Open",
                   accountID = 1,
                   entryTime = 1234, 
                   orderType = "Market",
                   timeInForce = "GTC",
                   symbol = "AAPL", 
                   userId = 1, 
                   clientOrderId = "AB12",
                   broker = "Interactive Brokers",
                   transactionTime = 55
               },
               new Order
               {
                   OrderId = 2,
                   productID = 2,
                   price = 20000, // Assuming price is in cents
                   quantity = 100,
                   side = "Sell",
                   orderStatus = "Open",
                   accountID = 2,
                   orderType = "Market",
                   entryTime =1234, // Assuming entryTime is in UTC ticks
                   symbol = "GOOGL",
                   userId= 2,
                   timeInForce="Day",
                   clientOrderId ="XZ31",
                   broker="Raheel Investors",
                   transactionTime=23

               }
           );
        }

    }
}

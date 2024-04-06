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
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.productID);
                entity.Property(p => p.lotSize)
                .IsRequired();
                entity.Property(p => p.tickSize)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
                entity.Property(p => p.field);
                
                entity.Property(p => p.qouteCurrency)
                .HasColumnType("nvarchar(3)");
                entity.Property(p => p.settleCurrency)
                .HasColumnType("nvarchar(3)");
                entity.Property(p => p.Description)
                .HasMaxLength(255);
                entity.Property(p => p.field)
                .HasColumnType("nvarchar(20)");


            });

            modelBuilder.Entity<Order>(entity =>
            {
               
                    entity.HasKey(o => o.OrderId);

                    entity.Property(o => o.price).IsRequired();
                    entity.Property(o => o.quantity).IsRequired();

                    entity.Property(o => o.side).HasColumnType("nvarchar(4)");
                    entity.Property(o => o.orderStatus).HasColumnType("nvarchar(4)");
                    entity.Property(o => o.orderType).HasColumnType("nvarchar(10)");
                    entity.Property(o => o.timeInForce).HasColumnType("nvarchar(3)");
                    entity.Property(o => o.symbol).HasColumnType("nvarchar(10)");
                    entity.Property(o => o.clientOrderId).HasColumnType("nvarchar(8)");
                    entity.Property(o => o.broker).HasColumnType("nvarchar(30)");
                    entity.Property(o => o.accountID).IsRequired().HasColumnType("nvarchar(8)"); ;
                    entity.Property(o => o.entryTime).IsRequired();
                    entity.Property(o => o.transactionTime).IsRequired();

                entity.HasOne<Product>(o => o.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(o => o.productID)
                    .OnDelete(DeleteBehavior.Cascade);
             });
            
            


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

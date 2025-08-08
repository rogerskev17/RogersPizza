using Microsoft.EntityFrameworkCore;
using RogersPizza.Models;

namespace RogersPizza.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.EnableSensitiveDataLogging();
        }

        //tables
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<GiftCard> GiftCards { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pizza>().ToTable("Pizza");
            builder.Entity<Order>().ToTable("Order");
            builder.Entity<GiftCard>().ToTable("Gift Card");
        }
    }
}
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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test;ConnectRetryCount=0");
            // base.OnConfiguring(optionsBuilder);
        }

        //tables
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pizza>().ToTable("Pizzas");
        }
    }
}
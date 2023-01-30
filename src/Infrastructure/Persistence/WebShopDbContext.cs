using Application.Interfaces;
using Domain.Models;
using Domain.Models.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence
{
    public class WebShopDbContext : DbContext, IWebShopDbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=webshop.db");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>(ConfigureAddress);
            builder.Entity<OrderItem>(ConfigureOrderItem);
        }

        private void ConfigureAddress(EntityTypeBuilder<Address> builder)
        {
            builder.HasNoKey();
            builder.Property(a => a.ZipCode)
                .HasMaxLength(18)
                .IsRequired();

            builder.Property(a => a.Street)
                .HasMaxLength(180)
                .IsRequired();

            builder.Property(a => a.State)
                .HasMaxLength(60);

            builder.Property(a => a.Country)
                .HasMaxLength(90)
                .IsRequired();

            builder.Property(a => a.City)
                .HasMaxLength(100)
                .IsRequired();
        }

        private void ConfigureOrderItem(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(i => i.OrderedProduct);
        }
    }
}

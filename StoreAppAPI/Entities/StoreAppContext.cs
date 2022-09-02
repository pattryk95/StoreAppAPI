using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppAPI.Entities
{
    public class StoreAppContext : DbContext
    {
        public StoreAppContext(DbContextOptions<StoreAppContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(
                eb =>
                {
                    eb.Property(p => p.Name)
                        .IsRequired()
                        .HasMaxLength(50);

                    eb.Property(p => p.Description)
                        .HasMaxLength(255);
                    eb.Property(p => p.Price)
                        .IsRequired()
                        .HasColumnType("money");
                    eb.Property(p => p.QuantityInStock)
                        .IsRequired();
                });

            modelBuilder.Entity<Brand>(
                eb =>
                {
                    eb.Property(b => b.Name)
                        .IsRequired()
                        .HasMaxLength(50);

                    eb.HasMany(b => b.Products)
                    .WithOne(p => p.Brand)
                    .HasForeignKey(p => p.BrandId);
                });

            modelBuilder.Entity<Category>(
                eb =>
                {
                    eb.Property(b => b.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                    eb.HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId);
                });

        }
    }
}

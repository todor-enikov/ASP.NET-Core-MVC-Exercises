using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarDealer.Data.Models;

namespace CarDealer.Data
{
    public class CarDealerSystemDbContext : IdentityDbContext<User>
    {
        public CarDealerSystemDbContext(DbContextOptions<CarDealerSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sale>()
                   .HasOne(s => s.Car)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(s => s.Car_Id);

            builder.Entity<Sale>()
                   .HasOne(s => s.Customer)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(s => s.Customer_Id);

            builder.Entity<Part>()
                   .HasOne(c => c.Supplier)
                   .WithMany(p => p.Parts)
                   .HasForeignKey(s => s.Supplier_Id);

            builder.Entity<PartCar>()
                   .HasKey(pc => new { pc.Car_Id, pc.Part_Id });

            builder.Entity<PartCar>()
                   .HasOne(pc => pc.Car)
                   .WithMany(c => c.Parts)
                   .HasForeignKey(pc => pc.Car_Id);

            builder.Entity<PartCar>()
                   .HasOne(pc => pc.Part)
                   .WithMany(c => c.Cars)
                   .HasForeignKey(pc => pc.Part_Id);

            base.OnModelCreating(builder);
        }
    }
}

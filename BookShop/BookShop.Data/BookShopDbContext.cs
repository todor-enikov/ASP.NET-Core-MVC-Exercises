using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Data
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("server=dev-enps-feedback-db.c5wrpvyoe6py.us-east-1.rds.amazonaws.com;database=ENPSTroubleshooter;user=admin;password=kvm$w1tch");
            optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;Database=webapi;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                        .HasOne(b => b.Author)
                        .WithMany(a => a.Books)
                        .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<CategoryBook>()
                        .HasKey(cb => new { cb.CategoryId, cb.BookId });

            modelBuilder.Entity<CategoryBook>()
                        .HasOne(cb => cb.Book)
                        .WithMany(c => c.Categories)
                        .HasForeignKey(cb => cb.BookId);

            modelBuilder.Entity<CategoryBook>()
                        .HasOne(cb => cb.Category)
                        .WithMany(b => b.Books)
                        .HasForeignKey(cb => cb.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

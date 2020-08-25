using EFCore.Example.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Example.Infrastructure
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options)
            : base(options)
        { }

        public DbSet<ProductDto> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDto>().ToTable("Product");
        }
    }
}

// Package manager console run the following command.
// Add-Migration EFCore.Example.Infrastructure.ExampleDbContext
// If successful we need to apply that migration so run the next command:
// update-database
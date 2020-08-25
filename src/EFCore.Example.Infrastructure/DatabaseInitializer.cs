using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.Example.Application.DTOs;
using Microsoft.EntityFrameworkCore.Internal;

namespace EFCore.Example.Infrastructure
{
    public static class DatabaseInitializer
    {
        public static void Seed(ExampleDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return; // If the DB has products then it's already seeded and this setup isn't needed to be run.
            }

            var products = new List<ProductDto>()
            {
                new ProductDto(){ Name = "Hello World", Description = "This is a test product!", IsActive = true },
                new ProductDto(){ Name = "Captain Marvel", Description = "This is a test product!", IsActive = true },
                new ProductDto(){ Name = "Thor", Description = "This is a test product!", IsActive = true },
                new ProductDto(){ Name = "Ms Marvel", Description = "This is a test product!", IsActive = true },
                new ProductDto(){ Name = "Aquaman", Description = "This is a test product!", IsActive = false },
                new ProductDto(){ Name = "Miles Morales", Description = "This is a test product!", IsActive = true }
            };

            foreach (var p in products)
            {
                context.Products.Add(p);
            }

            context.SaveChanges();
        }
    }
}

using System;
using System.Threading.Tasks;
using EFCore.Example.Application.DTOs;
using EFCore.Example.Domain.Interfaces;

namespace EFCore.Example.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<ProductDto> CreateProduct(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}

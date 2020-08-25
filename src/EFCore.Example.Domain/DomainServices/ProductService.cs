using System;
using System.Threading.Tasks;
using EFCore.Example.Application.DTOs;
using EFCore.Example.Domain.Interfaces;

namespace EFCore.Example.Domain.DomainServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<ProductDto> CreateProduct(ProductDto dto)
        {
            var createdProduct = await _repo.CreateProduct(dto);
            return createdProduct;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await _repo.GetProduct(id);
            return product;
        }
    }
}

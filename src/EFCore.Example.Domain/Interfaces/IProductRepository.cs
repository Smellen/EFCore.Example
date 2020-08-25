using System.Threading.Tasks;
using EFCore.Example.Application.DTOs;

namespace EFCore.Example.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDto> GetProduct(int id);
        Task<ProductDto> CreateProduct(ProductDto dto);
    }
}

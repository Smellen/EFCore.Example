﻿using System.Threading.Tasks;
using EFCore.Example.Application.DTOs;

namespace EFCore.Example.Domain.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(int id);
        Task<ProductDto> CreateProduct(ProductDto dto);
    }
}

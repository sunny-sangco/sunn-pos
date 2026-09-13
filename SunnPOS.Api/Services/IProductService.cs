using SunnPOS.Api.DTOs;
using SunnPOS.Api.Models;

namespace SunnPOS.Api.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(Guid id);

    Task<Product> CreateAsync(CreateProductRequest request);
}
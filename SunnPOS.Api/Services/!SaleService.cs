using SunnPOS.Api.DTOs.Sales;
using SunnPOS.Api.Models;

namespace SunnPOS.Api.Services;

public interface ISaleService
{
    Task<IEnumerable<Sale>> GetAllAsync();

    Task<Sale?> GetByIdAsync(Guid id);

    Task<Sale> CreateAsync(CreateSaleRequest request);
}
using SunnPOS.Api.DTOs.Sales;
using SunnPOS.Api.Models;

namespace SunnPOS.Api.Services;

public class SaleService : ISaleService
{
    //TODO implement SaleService to the sales/transaction.
    public Task<Sale> CreateAsync(CreateSaleRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Sale>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Sale?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
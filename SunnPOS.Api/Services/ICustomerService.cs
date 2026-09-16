using SunnPOS.Api.DTOs.Customers;
using SunnPOS.Api.Models;

namespace SunnPOS.Api.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllAsync();

    Task<Customer?> GetByIdAsync(Guid id);

    Task<Customer> CreateAsync(CreateCustomerRequest request);

    Task<Customer?> UpdateAsync(
        Guid id,
        UpdateCustomerRequest request);

    Task<bool> DeleteAsync(Guid id);
}
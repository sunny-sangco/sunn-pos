using SunnPOS.Api.DTOs.Customers;
using SunnPOS.Api.Models;

namespace SunnPOS.Api.Services;

public class CustomerService : ICustomerService
{
    private readonly List<Customer> _customers = new();

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Customer>>(_customers);
    }

    public Task<Customer?> GetByIdAsync(Guid id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);

        return Task.FromResult(customer);
    }

    public Task<Customer> CreateAsync(CreateCustomerRequest request)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            CreatedAt = DateTime.UtcNow
        };

        _customers.Add(customer);

        return Task.FromResult(customer);
    }

    public Task<Customer?> UpdateAsync(
        Guid id,
        UpdateCustomerRequest request)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);

        if (customer is null)
            return Task.FromResult<Customer?>(null);

        customer.Name = request.Name;
        customer.PhoneNumber = request.PhoneNumber;
        customer.Email = request.Email;

        return Task.FromResult<Customer?>(customer);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);

        if (customer is null)
            return Task.FromResult(false);

        _customers.Remove(customer);

        return Task.FromResult(true);
    }
}
using Business.Models;
using Data.Repositories;
using Business.Factories;

namespace Business.Services;

public class CustomerService(CustomerRepository customerRepository)
{
    private readonly CustomerRepository _customerRepository = customerRepository;

    public async Task CreateCustomerAsync(CustomerRegistrationForm form) 
    {
        var customerEntity = CustomerFactory.Create(form);
        await _customerRepository.AddAsync(customerEntity!);
    }
    public async Task<IEnumerable<Customer?>> GetCustomerAsync()
    {
        var customerEntities = await _customerRepository.GetAsync();
        return customerEntities.Select(CustomerFactory.Create);
    }
    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.id == id);
        return CustomerFactory.Create(customerEntity!);
    }
    public async Task<Customer?> GetCustomerByCustomerNameAsync(string customerName) 
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.CustomerName == customerName);
        return CustomerFactory.Create(customerEntity!);
    }
    public async Task<bool> UpdateCustomerAsync(Customer customer) { }
    public async Task<bool> DeleteCustomerAsync(int id) { }
}

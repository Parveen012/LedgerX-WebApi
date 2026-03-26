using Application.Dtos;

namespace Application.Customers;

public interface ICustomerApplication
{
    public Task AddCustomer(CreateUpdateCustomerDto input);
    public Task UpdateCustomer(int id,CreateUpdateCustomerDto input);
    public Task DeleteCustomer(int id);
    public Task<GetCustomerDto> GetCustomerById(int id);
    public Task<List<GetCustomerDto>> GetAllCustomers();
    public Task Block(int id);
}

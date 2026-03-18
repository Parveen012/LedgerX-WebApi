using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Customers;

public interface ICustomerRepository
{
    public Task Create(Customer customer);
    public Task<Customer> GetById(int  id);
    public Task<List<Customer>> GetAll();
    public Task Update(Customer customer);
    public Task Delete(Customer customer);
}

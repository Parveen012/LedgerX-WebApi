using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly DataContext _datacontext;

    public CustomerRepository(DataContext datacontext)
    {
        _datacontext = datacontext;
    }

    public async Task Create(Customer customer)
    {
       await _datacontext.Customers.AddAsync(customer);
        await _datacontext.SaveChangesAsync();
    }

    public Task Delete(Customer customer)
    {
        
        customer.IsDeleted = true;
        customer.IsActive = false;
        _datacontext.Customers.Update(customer);
        return _datacontext.SaveChangesAsync();

    }

    public async Task<List<Customer>> GetAll()
    {
        return await _datacontext.Customers.ToListAsync();
    }

    public async Task<Customer> GetById(int id)
    {
        return await _datacontext.Customers.FindAsync(id);
    }

    public Task Update(Customer customer)
    {
        _datacontext.Customers.Update(customer);
       return  _datacontext.SaveChangesAsync();

    }
    public Task Block(Customer customer)
    {
        customer.IsActive=!customer.IsActive;
          _datacontext.Customers.Update(customer);
        return  _datacontext.SaveChangesAsync();
    }
}

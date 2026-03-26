using Application.Dtos;
using AutoMapper;
using Domain;
using Infrastructure.Repositories.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers;

public class CustomerApplication : ICustomerApplication
{
    private readonly ICustomerRepository _customerRepository;

    private readonly IMapper _mapper;
    public CustomerApplication(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task AddCustomer(CreateUpdateCustomerDto input)
    {
        var customer = _mapper.Map<Customer>(input);
        await _customerRepository.Create(customer);
    }

    public async Task DeleteCustomer(int id)
    {
        var customer = await _customerRepository.GetById(id);
        if(customer==null)
        {
            return;
        }
        await _customerRepository.Delete(customer);
    }

    public async Task<List<GetCustomerDto>> GetAllCustomers()
    {
        var customers = await _customerRepository.GetAll();
        return _mapper.Map<List<GetCustomerDto>>(customers);
    }

    public async Task<GetCustomerDto> GetCustomerById(int id)
    {
        var customer = await _customerRepository.GetById(id);
        if (customer == null) { 
            return new GetCustomerDto();
        }
        return _mapper.Map<GetCustomerDto>(customer);
    }

    public async Task UpdateCustomer(int id, CreateUpdateCustomerDto input)
    {
        var customer = await _customerRepository.GetById(id);
        if (customer == null)
        {
            return;
        }
        _mapper.Map(input, customer);
        await _customerRepository.Update(customer);
    }

    public async Task Block(int id)
    {
        var customer = await _customerRepository.GetById(id);
        if (customer == null)
        {
            return;
        }
        await _customerRepository.Block(customer);
    }
}

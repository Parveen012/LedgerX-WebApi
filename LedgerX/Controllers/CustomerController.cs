using Application.Customers;
using Application.Dtos;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace LedgerX.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerApplication _customerApplication;

    public CustomerController(ICustomerApplication customerApplication)
    {
        _customerApplication = customerApplication;
    }

    

    [HttpPost]
    public async Task<ActionResult> AddCustomer(CreateUpdateCustomerDto input)
    {
        try
        {
            await _customerApplication.AddCustomer(input);
            return Ok();
        }
        catch
        {
            return BadRequest();
            
        }


    }


    [HttpGet]
    public async Task<List<GetCustomerDto>> GetAll()
    {
        return await _customerApplication.GetAllCustomers();
    }

    [HttpGet("{id}")]
    public async Task<GetCustomerDto> GetById(int id)
    {
        return await _customerApplication.GetCustomerById(id);
    }


    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _customerApplication.DeleteCustomer(id);
    }

    [HttpPut("{id}")]
    public async Task Update(int id, CreateUpdateCustomerDto input)
    {
        await _customerApplication.UpdateCustomer(id, input);

    }



}

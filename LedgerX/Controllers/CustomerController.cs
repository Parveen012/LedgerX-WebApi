using Application.Dtos;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LedgerX.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly DataContext _dataContext;

    public CustomerController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpPost]
    public void Create(CreateUpdateCustomerDto input)
    {
        var customer = new Customer
        {
            Name = input.Name,
            Email = input.Email,
            PhoneNumber = input.PhoneNumber,
            Notes = input.Notes,
        };
        _dataContext.Customers.Add(customer);
        _dataContext.SaveChanges();


    }


    [HttpGet]
    public List<GetCustomerDto> Get()
    {
        return _dataContext.Customers.Select(x=>new GetCustomerDto
        {
            Id = x.Id, Name = x.Name, Email = x.Email, PhoneNumber = x.PhoneNumber,IsActive = x.IsActive,
        }).ToList();
    }

}

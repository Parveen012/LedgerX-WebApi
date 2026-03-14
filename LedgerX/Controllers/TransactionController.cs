using Application.Dtos;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public TransactionController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public void Create(CreateUpdateTransactionDto input)
        {
            bool isCustomerExists = _dataContext.Customers.Any(p => p.Id == input.CustomerId);
            if (!isCustomerExists)
            {
                throw new BadHttpRequestException($"Cutomer ID {input.CustomerId} doesn't exists");

            }
            var transaction = new Transaction
            {
                CustomerId = input.CustomerId,
                Amount= input.Amount,
                TransactionType = input.TransactionType,
                Description = input.Description,
        
            };
            _dataContext.Add(transaction);
            _dataContext.SaveChanges();
        }

        [HttpGet]
        public List<GetTransactionDto> Get()
        {
            return _dataContext.Transactions.Include(x=>x.Customer).Select(x=> new GetTransactionDto
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                Amount= x.Amount,
                Description = x.Description,
                TransactionType= x.TransactionType,
              customer=x.Customer,
            }).ToList();
        }


    }
}

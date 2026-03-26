using Application.Dtos;
using Application.Transactions;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionApplication _transactionApplication;

        public TransactionController(ITransactionApplication transactionApplication)
        {
            _transactionApplication = transactionApplication;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddTransaction(CreateUpdateTransactionDto input)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == "userId")?.Value;
               if (userIdClaim == null)
                {
                    return Unauthorized();
                }

                await _transactionApplication.AddTransaction(input, userIdClaim);
                return Ok();
            }
            catch
            {
                return BadRequest();

            }

        }


        [HttpGet]
        public async Task<List<GetTransactionDto>> GetAll()
        {
            return await _transactionApplication.GetAllTransactions();
        }

        [HttpGet("{id}")]
        public async Task<GetTransactionDto> GetById(int id)
        {
            return await _transactionApplication.GetTransactionById(id);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _transactionApplication.DeleteTransaction(id);
        }

        [HttpPut("{id}")]
        public async Task Update(int id, CreateUpdateTransactionDto input)
        {
            await _transactionApplication.UpdateTransaction(id, input);

        }
        


    }
}

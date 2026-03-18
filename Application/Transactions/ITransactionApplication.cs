using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transactions
{
    public interface ITransactionApplication
    {
        public Task AddTransaction(CreateUpdateTransactionDto input);
        public Task UpdateTransaction(int id, CreateUpdateTransactionDto input);
        public Task DeleteTransaction(int id);
        public Task<GetTransactionDto> GetTransactionById(int id);
        public Task<List<GetTransactionDto>> GetAllTransactions();
    }
}

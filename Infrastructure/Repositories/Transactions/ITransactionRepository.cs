using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Transactions
{
    public interface ITransactionRepository
    {
        public Task Create(Transaction trasnsaction);
        public Task<Transaction> GetById(int id);
        public Task<List<Transaction>> GetAll();
        public Task Update(Transaction trasnsaction);
        public Task Delete(Transaction trasnsaction);

    }
}

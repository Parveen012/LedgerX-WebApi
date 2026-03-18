using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Transactions
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _datacontext;

        public TransactionRepository(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task Create(Transaction transaction)
        {
            await _datacontext.Transactions.AddAsync(transaction);
            await _datacontext.SaveChangesAsync();
        }

        public Task Delete(Transaction transaction)
        {

            transaction.IsDeleted = true;
            transaction.IsActive = false;
            _datacontext.Transactions.Update(transaction);
            return _datacontext.SaveChangesAsync();

        }

        public async Task<List<Transaction>> GetAll()
        {
            return await _datacontext.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetById(int id)
        {
            return await _datacontext.Transactions.FindAsync(id);
        }

        public Task Update(Transaction transaction)
        {
            _datacontext.Transactions.Update(transaction);
            return _datacontext.SaveChangesAsync();

        }
    }
}

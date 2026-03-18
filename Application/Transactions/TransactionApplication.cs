using Application.Dtos;
using AutoMapper;
using Domain;
using Infrastructure.Repositories.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transactions
{
    public class TransactionApplication:ITransactionApplication
    {
        private ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionApplication(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task AddTransaction(CreateUpdateTransactionDto input)
        {
            var transaction = _mapper.Map<Transaction>(input);
            await _transactionRepository.Create(transaction);
        }

        public async Task DeleteTransaction(int id)
        {
            var transaction = await _transactionRepository.GetById(id);
            if (transaction == null)
            {
                return;
            }
            await _transactionRepository.Delete(transaction);
        }

        public async Task<List<GetTransactionDto>> GetAllTransactions()
        {
            var transactions = await _transactionRepository.GetAll();
            return _mapper.Map<List<GetTransactionDto>>(transactions);
        }

        public async Task<GetTransactionDto> GetTransactionById(int id)
        {
            var transaction = await _transactionRepository.GetById(id);
            if (transaction == null)
            {
                return new GetTransactionDto();
            }
            return _mapper.Map<GetTransactionDto>(transaction);
        }

        public async Task UpdateTransaction(int id, CreateUpdateTransactionDto input)
        {
            var transaction = await _transactionRepository.GetById(id);
            if (transaction == null)
            {
                return;
            }
            _mapper.Map(input, transaction);
            await _transactionRepository.Update(transaction);
        }
    }
}

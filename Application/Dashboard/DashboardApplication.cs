using Application.Dtos;
using Domain.Enum;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dashboard
{
    public class DashboardApplication: IDashboardApplication
    {
        private readonly DataContext _context;
        public DashboardApplication(DataContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> GetDashboard()
        {
            var credits =await _context.Transactions.Where(t=>t.TransactionType == TransactionType.Credit).SumAsync(t => t.Amount);
            var debits = await _context.Transactions.Where(t=>t.TransactionType == TransactionType.Debit).SumAsync(t => t.Amount);
            var totalAmount = credits - debits;

            return new DashboardDto
            {
                Credits = credits,
                Debits = debits,
                TotalAmount = totalAmount
            };
        }
    }
}

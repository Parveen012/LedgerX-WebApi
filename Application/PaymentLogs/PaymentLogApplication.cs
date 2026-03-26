using Application.Dtos;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.PaymentLogs
{
    public class PaymentLogApplication: IPaymentLogApplication
    {
        private readonly DataContext _datacontext;

        public PaymentLogApplication(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        //public async Task<List<PaymentLogDto>> GetPaymentLogsAsync()
        //{
               
            
        //   var paymentLogs = await _datacontext.Transactions.Select(x=> new PaymentLogDto
        //    {
        //        TransactionId = x.Id,
        //        Amount = x.Amount,
        //        TransactionType = x.TransactionType,
        //        Date = x.CreatedDate,
        //        CustomerId = x.CustomerId,
        //        CustomerName = x.Customer.Name,
              
        //    }).ToListAsync();

        //    return paymentLogs;
        //}
    }
}

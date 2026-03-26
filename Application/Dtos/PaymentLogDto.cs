using Domain;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class PaymentLogDto
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; } 

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        //public string UserId { get; set; }
        //public string UserName { get; set; }
        //public string Role { get; set; }

    }
}

using Domain;
using Domain.Enum;

namespace Application.Dtos;

public class GetTransactionDto
{
    public int Id { get; set; }
    public TransactionType TransactionType { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }

    public int CustomerId { get; set; }
    public Customer? customer { get; set; }
}

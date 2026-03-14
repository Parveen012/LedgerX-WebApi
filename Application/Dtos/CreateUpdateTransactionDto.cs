using Domain.Enum;

namespace Application.Dtos;

public class CreateUpdateTransactionDto
{
    public int CustomerId { get; set; }
    public TransactionType TransactionType { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }
}

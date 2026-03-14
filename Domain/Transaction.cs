using Domain.Common;
using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Transaction:BaseEntity
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Customers")]
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public TransactionType TransactionType { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }
}

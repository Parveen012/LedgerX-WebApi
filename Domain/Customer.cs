using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Customer:BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? Notes { get; set; }



}

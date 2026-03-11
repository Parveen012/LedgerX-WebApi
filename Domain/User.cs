using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class User:BaseEntity
{
    [Key]
    public int Id { get; set; }

    public Role Role { get; set; }

    public string firstName { get; set; }
    public string lastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int PinCode { get; set; }
    public string Password { get; set; }
}

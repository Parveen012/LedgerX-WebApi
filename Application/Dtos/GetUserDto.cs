
using System.Data;

namespace Application.Dtos;

public class GetUserDto
{
    public int Id { get; set; }

    public string Role { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int PinCode { get; set; }
}

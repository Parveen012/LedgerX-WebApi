namespace Application.Dtos;

public class CreateUpdateCustomerDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? Notes { get; set; }
}

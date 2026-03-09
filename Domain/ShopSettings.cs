using System.ComponentModel.DataAnnotations;

namespace Domain;

public class ShopSettings
{
    [Key]
    public int Id { get; set; }
    public string ShopName { get; set; }
    public string OwnerName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? GstNumber { get; set; }
    public int EmployeeId { get; set; }


}

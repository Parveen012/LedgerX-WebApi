using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Customers
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public string Notes { get; set; }
    public int Balance { get; set; }
    public string Profile { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;


}

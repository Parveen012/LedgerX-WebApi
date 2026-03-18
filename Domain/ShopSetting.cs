using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class ShopSetting:BaseEntity
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
    public string ShopName { get; set; }
    public string OwnerName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? GstNumber { get; set; }


}

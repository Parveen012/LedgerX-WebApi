using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Dtos;

public class GetShopSettingsDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ShopName { get; set; }
    public string OwnerName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? GstNumber { get; set; }
    public User User { get; set; }
}

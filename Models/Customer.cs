using System;

namespace Ecommerce.Api.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public  string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string RefreshToken {get;set;} = string.Empty;
    public DateTime RefreshTokenExpiryTime {get; set;}
    public bool IsRevoked{get; set;} = false;
    public DateTime CreatedAt{ get; set; }
}

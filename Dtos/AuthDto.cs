using System;

namespace Ecommerce.Api.Dtos;

public class AuthDto
{
    public string PasswordHash { get; set; } = string.Empty;
    public string Email { get; set; }= string.Empty;
}

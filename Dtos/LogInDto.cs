using System;

namespace Ecommerce.Api.Dtos;

public class LogInDto
{
    public string? AccessToken{get; set;}
    public string? RefreshToken{get;set;}
}

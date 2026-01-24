using System.Security.Claims;
using Ecommerce.Api.Dtos;
using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;


namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(AppDbContext context, IConfiguration _configuration ) : ControllerBase
    {
        private readonly AppDbContext _context = context; 
        private readonly IConfiguration configuration = _configuration;
        public record Req(string Token);
       

       [HttpPost("register")]
       public async Task<ActionResult<Customer>> Register(AuthDto request)
        {
           if(_context.Customers.Any(u => u.Email == request.Email)) return BadRequest("email already exists");
       var customer = new Customer
       {
           Email = request.Email
       };
       customer.PasswordHash = new PasswordHasher<Customer>().HashPassword(customer, request.PasswordHash);
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        customer.PasswordHash = "";
        return Ok(customer);
        
        } 

        [HttpPost("login")]
        public async Task<ActionResult<LogInDto>> Login(AuthDto request)
        {
            var FoundCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == request.Email);
            if(FoundCustomer == null) return Unauthorized("invalid log in credentials");

            var result = new PasswordHasher<Customer>().VerifyHashedPassword(FoundCustomer, FoundCustomer.PasswordHash, request.PasswordHash);
            if (result == PasswordVerificationResult.Failed) return Unauthorized("invalid Password");
        
        //generate jwt token and return
        string accessToken =  GenerateJwt(FoundCustomer);
        string refreshToken = GetRefreshtoken();
        FoundCustomer.RefreshToken = refreshToken;
        FoundCustomer.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
    await _context.SaveChangesAsync();
    return new LogInDto() {AccessToken = accessToken, RefreshToken = refreshToken};
        }
        private string GenerateJwt (Customer customer)
        {
            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()), 
              new(ClaimTypes.Email, customer.Email) 
            };
            
            var Mykey = configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(Mykey)) throw new Exception("Jwt key is missing");

            var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(Mykey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"] ,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
       
       private static string GetRefreshtoken ()
        {
            var RandomNum = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(RandomNum);
            return Convert.ToBase64String(RandomNum);
        }
    [HttpPost("refresh")]
    public async Task<LogInDto> RefreshToken (Req token)
        {
           var foundToken = await _context.Customers.FirstOrDefaultAsync(r => r.RefreshToken == token.Token) ?? throw new Exception("invalid token");
    
           var customer = await _context.Customers.FirstOrDefaultAsync(r => r.Id == foundToken.Id) ?? throw new Exception("customer not found");
           if (customer.RefreshTokenExpiryTime < DateTime.UtcNow)
            {
                throw new ApplicationException("the refresh token has expired");
            }
            string accessToken = GenerateJwt(customer);
            customer.RefreshToken = GetRefreshtoken();
            customer.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();
            return new LogInDto() {AccessToken = accessToken, RefreshToken = customer.RefreshToken};
        }
    }
}

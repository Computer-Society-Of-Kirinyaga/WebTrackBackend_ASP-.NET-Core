using System;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Models;

public class AppDbContext : DbContext
{
    public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<ProductDto> Products {get; set;}
}

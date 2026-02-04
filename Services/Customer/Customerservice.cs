using Ecommerce.Api.Migrations;
using Ecommerce.Api.Models;
using Microsoft.EntityFrameworkCore;

public class CustomerService (AppDbContext context) : ICustomerService
{
    private readonly AppDbContext _context = context;
    public List<CustomerDto> GetCustomers ()
    {
        return _context.Customers
            .Select(c => new CustomerDto { Name = c.Name, Email = c.Email })
            .ToList();
    }
    public CustomerDto CreateCustomer(CustomerDto customerdto)
    {
        var newCustomer = new Customer
        {
            Name = customerdto.Name,
            Email = customerdto.Email
        };
        _context.Customers.Add(newCustomer);
        _context.SaveChanges();
        return new CustomerDto { Name = newCustomer.Name, Email = newCustomer.Email };
    }
    public CustomerDto? UpdateCustomer(int id, CustomerDto dto)
    {
        var currProg = _context.Customers.Find(id);
        if (currProg == null) return null;

        if(dto.Name != null) currProg.Name = dto.Name;
        if(dto.Email != null) currProg.Email = dto.Email;

        _context.SaveChanges();

       return new CustomerDto { Name = currProg.Name, Email = currProg.Email };   
 }
    public bool Deletecustomer(int id)
    {
        var cust = _context.Customers.Find(id);
        if( cust == null)
        {
            return false;
        } else
        {
            _context.Customers.Remove(cust);
            _context.SaveChanges();
            return true;
        }
    }
    public CustomerDto? GetCustomerById(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        if (customer == null) return null;
        return new CustomerDto { Name = customer.Name, Email = customer.Email };
    }
}
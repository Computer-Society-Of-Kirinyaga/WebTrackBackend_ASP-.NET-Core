public class CustomerService : ICustomerService
{
    private readonly List<CustomerDto> customers = [];
    private int nextId = 1;
    public CustomerService()
    {
        customers.Add(new CustomerDto { Id = nextId++, Name = "Alice Smith", Email = "alice@example.com" });
        customers.Add(new CustomerDto { Id = nextId++, Name = "Bob Johnson", Email = "bob@example.com" });
    }
    public List<CustomerDto> GetCustomers() => customers;
    public CustomerDto? GetCustomerById(int id) => customers.FirstOrDefault(c => c.Id == id);
    public CustomerDto CreateCustomer(CustomerDto customer)
    {
        customer.Id = nextId++;
        customers.Add(customer);
        return customer;
    }
    public CustomerDto? UpdateCustomer(int id, CustomerDto customer)
    {
        var existingcustomer = GetCustomerById(id);
        if (existingcustomer == null) return null;

        existingcustomer.Name = customer.Name;
        existingcustomer.Email = customer.Email;
        return existingcustomer;
    }
     public bool Deletecustomer(int id)
    {
        var customer = GetCustomerById(id);
        if (customer == null) return false;

        return customers.Remove(customer);
    }
}
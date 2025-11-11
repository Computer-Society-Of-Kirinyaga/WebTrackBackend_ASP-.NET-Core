public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public required string Email { get; set; }
    public DateTime CreatedAt{ get; set; }
}
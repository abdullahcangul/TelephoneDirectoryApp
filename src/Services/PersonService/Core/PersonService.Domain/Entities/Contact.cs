namespace PersonService.Domain.Entities;

public class Contact:BaseEntity
{
    public string? TelNo { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

    public Guid PersonUUID { get; set; }
    public Person Person { get; set; }
}
namespace PersonService.Application.DTOs.ContactDto;

public class ContactDto
{
    public Guid UUID { get; set; }
    public string? TelNo { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

    public Guid PersonUUID { get; set; }
}
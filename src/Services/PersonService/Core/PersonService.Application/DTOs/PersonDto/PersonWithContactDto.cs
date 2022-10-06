using PersonService.Domain.Entities;

namespace PersonService.Application.DTOs.PersonDto;

public class PersonWithContactDto
{
    public PersonWithContactDto()
    {
        Contacts = new List<ContactForListDto>();
    }
    public Guid UUID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<ContactForListDto> Contacts { get; set; }
}

public class ContactForListDto:IDto
{
    public Guid UUID { get; set; }
    public string? TelNo { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

}
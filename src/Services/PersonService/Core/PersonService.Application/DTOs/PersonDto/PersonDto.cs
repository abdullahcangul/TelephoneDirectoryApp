namespace PersonService.Application.DTOs.PersonDto;

public class PersonDto:IDto
{
    public Guid UUID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}
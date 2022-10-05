namespace PersonService.Domain.Entities;

public class Person:BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<Contact> Contacts { get; set; }
}
using PersonService.Application.Abstractions.Services;
using PersonService.Application.Repositories;
using PersonService.Domain.Entities;

namespace PersonService.Persistence.Services;

public class ContactManager:BaseManager<Contact>,IContactService
{
    public ContactManager(IReadRepository<Contact> readRepository, IWriteRepository<Contact> writeRepository) : base(readRepository, writeRepository)
    {
    }
}
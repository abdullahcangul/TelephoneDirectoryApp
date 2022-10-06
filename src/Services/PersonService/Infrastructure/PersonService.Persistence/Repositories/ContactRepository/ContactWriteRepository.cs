using PersonService.Application.Repositories.ContactRepository;
using PersonService.Domain.Entities;
using PersonService.Persistence.Contexts;

namespace PersonService.Persistence.Repositories.ContactRepository;

public class ContactWriteRepository:WriteRepository<Contact>,IContactWriteRepository
{
    public ContactWriteRepository(TDPersonServiceContextDB context) : base(context)
    {
    }
}
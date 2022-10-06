using PersonService.Application.Repositories;
using PersonService.Application.Repositories.ContactRepository;
using PersonService.Domain.Entities;
using PersonService.Persistence.Contexts;

namespace PersonService.Persistence.Repositories.ContactRepository;

public class ContactReadRepository:ReadRepository<Contact>,IContactReadRepository
{
    public ContactReadRepository(TDPersonServiceContextDB context) : base(context)
    {
    }
}
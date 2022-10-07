using Microsoft.EntityFrameworkCore;
using PersonService.Application.Abstractions.Services;
using PersonService.Application.DTOs.ReportDto;
using PersonService.Application.Repositories;
using PersonService.Application.Repositories.ContactRepository;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Persistence.Services;

public class ContactManager:BaseManager<Contact>,IContactService
{
    private readonly IContactReadRepository _contactReadRepository;
    public ContactManager(IReadRepository<Contact> readRepository, IWriteRepository<Contact> writeRepository, IContactReadRepository contactReadRepository) : base(readRepository, writeRepository)
    {
        _contactReadRepository = contactReadRepository;
    }
    
    public async Task<IDataResult<List<ReportDto>>> GetReports()
    {
        return new SuccessDataResult<List<ReportDto>>(
                await _contactReadRepository.GetAll()
                    .GroupBy(c=>c.Address)
                    .Select(c=>new ReportDto()
                    {
                        Address = c.Key,
                        TelNoCount = c.ToList().Select(p=>p.TelNo).Count(),
                        PersonCount = c.ToList().Select(p=>p.PersonUUID).Distinct().Count()
                    }).ToListAsync()
            );
    }
}
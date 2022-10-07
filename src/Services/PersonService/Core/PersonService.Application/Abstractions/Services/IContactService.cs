using PersonService.Application.DTOs.ReportDto;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Application.Abstractions.Services;

public interface IContactService:IBaseService<Contact>
{
    public Task<IDataResult<List<ReportDto>>> GetReports();
    
}
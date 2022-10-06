
using ReportService.Application.Utility.Results;
using ReportService.Domain.Entities;

namespace ReportService.Application.Abstractions.Services;

public interface IBaseService<T> where T :  BaseEntity
{
    Task<IDataResult<T>> AddAsync(T entity);
    Task<IDataResult<List<T>>> AddRangeAsync(List<T> entity);
    Task<IResult> DeleteAsync(T entity);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult> UpdateAsync(T entity);
    Task<IDataResult<T>>  GetByIdAsync(Guid id);
    Task<IDataResult<List<T>>> GetAllAsync();
}
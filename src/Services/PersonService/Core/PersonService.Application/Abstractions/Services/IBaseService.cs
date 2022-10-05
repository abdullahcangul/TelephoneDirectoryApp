using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Application.Abstractions.Services;

public interface IBaseService<T> where T :  BaseEntity
{
    Task<IDataResult<T>> AddAsync(T entity);
    Task<IDataResult<List<T>>> AddRangeAsync(List<T> entity);
    Task<IResult> Delete(T entity);
    Task<IResult> UpdateAsync(T entity);
    Task<IDataResult<T>>  GetByIdAsync(Guid id);
    Task<IDataResult<List<T>>> GetAllAsync();
}
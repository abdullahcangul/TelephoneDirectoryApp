using Microsoft.EntityFrameworkCore;
using PersonService.Application.Abstractions.Services;
using PersonService.Application.Repositories;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Persistence.Services;

public class BaseManager<T>:IBaseService<T> where T : BaseEntity
{
    private readonly IReadRepository<T> _readRepository;
    private readonly IWriteRepository<T> _writeRepository;

    public BaseManager(IReadRepository<T> readRepository, IWriteRepository<T> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task<IDataResult<T>> AddAsync(T entity)
    {
        var result= await _writeRepository.AddAsync(entity);
        if (result == null)
        {
            return new ErrorDataResult<T>();
        }
        return new SuccessDataResult<T>(result);

    }

    public async Task<IDataResult<List<T>>> AddRangeAsync(List<T> entity)
    {
        var result= await _writeRepository.AddRangeAsync(entity);
        if (result == null)
        {
            return new ErrorDataResult<List<T>>();
        }
        return new SuccessDataResult<List<T>>(result);
    }

    public async Task<IResult> Delete(T entity)
    {
        var result= await _writeRepository.RemoveAsync(entity.UUID);
        if (result)
        {
            return new ErrorResult(false);
        }
        return new SuccessResult();
    }

    public IResult UpdateAsync(T entity)
    {
        var result=  _writeRepository.Update(entity);
        if (result)
        {
            return new ErrorResult(false);
        }
        return new SuccessResult();
    }

    public async Task<IDataResult<T>> GetByIdAsync(Guid id)
    {
        var result= await  _readRepository.GetByIdAsync(id);
        if (result==null)
        {
            return new ErrorDataResult<T>();
        }
        return new SuccessDataResult<T>(result);
    }

    public async Task<IDataResult<List<T>>> GetAllAsync()
    {
        var result=await  _readRepository.GetAll().ToListAsync();
        if (result!=null)
        {
            return new ErrorDataResult<List<T>>();
        }
        return new SuccessDataResult<List<T>>(result);
    }
}
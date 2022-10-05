using PersonService.Domain.Entities;

namespace PersonService.Application.Repositories;

public interface IWriteRepository<T>: IRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T model);
    Task<List<T>> AddRangeAsync(List<T> datas);
    bool Remove(T model);
    bool RemoveRange(List<T> datas);
    Task<bool> RemoveAsync(Guid id);
    bool Update(T model);

    Task<int> SaveAsync();
}
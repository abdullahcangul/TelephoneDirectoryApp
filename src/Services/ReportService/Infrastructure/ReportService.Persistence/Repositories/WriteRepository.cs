using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReportService.Application.Repositories;
using ReportService.Domain.Entities;
using ReportService.Persistence.Contexts;

namespace ReportService.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    readonly private TDReportServiceContextDB _context;
    public WriteRepository(TDReportServiceContextDB context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    public async Task<T> AddAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.Entity;
    }
    public async Task<List<T>> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return datas;
    }
    public bool Remove(T model)
    {
        EntityEntry<T> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }
    public bool RemoveRange(List<T> datas)
    {
        Table.RemoveRange(datas);
        return true;
    }
    public async Task<bool> RemoveAsync(Guid id)
    {
        T model = await Table.FirstOrDefaultAsync(data => data.UUID == id);
        if (model == null) return false;
        return Remove(model);
    }
    public bool Update(T model)
    {
        EntityEntry entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }
    public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();


}
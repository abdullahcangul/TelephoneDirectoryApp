using Microsoft.EntityFrameworkCore;
using PersonService.Domain.Entities;

namespace PersonService.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}
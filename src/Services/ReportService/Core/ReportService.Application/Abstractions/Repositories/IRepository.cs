using Microsoft.EntityFrameworkCore;
using ReportService.Domain.Entities;

namespace ReportService.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}
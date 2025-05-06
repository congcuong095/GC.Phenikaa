using Application.Repositories;

namespace Application.UnitOfWork;

public interface IUnitOfWork
{
    IEmployeeRepository EmployeeRepository { get; }
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollBackAsync();
    Task SaveChangesAsync();
}

using Application.Repositories;

namespace Application.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository EmployeeRepository { get; }
    IZaloMessageLogRepository ZaloMessageLogRepository { get; }
    IZaloTokenRepository ZaloTokenRepository { get; }
    ISMSMessageLogRepository SMSMessageLogRepository { get; }
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollBackAsync();
    Task SaveChangesAsync();
}

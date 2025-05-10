using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Infrastructure.DBAgent.Postgre.Context;
using Infrastructure.DBAgent.Postgre.Repositories;

namespace Infrastructure.DBAgent.Postgre.UnitOfWork;

public class PostgreUnitOfWork : IUnitOfWork
{
    private readonly PostgreDBContext _context;

    public IEmployeeRepository EmployeeRepository { get; }
    public IZaloMessageLogRepository ZaloMessageLogRepository { get; }
    public IZaloTokenRepository ZaloTokenRepository { get; }
    public ISMSMessageLogRepository SMSMessageLogRepository { get; }

    public PostgreUnitOfWork(PostgreDBContext context, IMapper mapper)
    {
        _context = context;

        EmployeeRepository = new PostgreEmployeeRepository(context, mapper);
        ZaloMessageLogRepository = new PostgreZaloMessageLogRepository(context, mapper);
        ZaloTokenRepository = new PostgreZaloTokenRepository(context, mapper);
        SMSMessageLogRepository = new PostgreSMSMessageLogRepository(context, mapper);
    }

    public async Task BeginTransactionAsync()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task RollBackAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

using System.Data;
using Application.GCRepositories;
using Application.GCUnitOfWork;
using AutoMapper;
using Infrastructure.DBGC.SqlServer.ConnectionFactory;
using Infrastructure.DBGC.SqlServer.Repositories;

namespace Infrastructure.DBGC.SqlServer.UnitOfWork;

public class SqlServerUnitOfWork : IGCUnitOfWork
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public IEmployeeCertificateRepository EmployeeCertificate { get; }

    public IAgentMessageRepository AgentMessage { get; }

    public SqlServerUnitOfWork(ISqlServerConnectionFactory connectionFactory, IMapper mapper)
    {
        _connection = connectionFactory.CreateConnection();
        _transaction = _connection.BeginTransaction();

        EmployeeCertificate = new SqlServerUserCertificateRepository(
            _connection,
            _transaction,
            mapper
        );
        AgentMessage = new SqlServerAgentMessageRepository(_connection, _transaction, mapper);
    }

    public void Commit()
    {
        _transaction?.Commit();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _connection?.Dispose();
    }
}

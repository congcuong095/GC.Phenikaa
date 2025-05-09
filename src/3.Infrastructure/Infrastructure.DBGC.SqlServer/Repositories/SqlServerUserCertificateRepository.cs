using System.Data;
using Application.GCRepositories;
using AutoMapper;
using Dapper;

namespace Infrastructure.DBGC.SqlServer.Repositories;

public class SqlServerUserCertificateRepository : IEmployeeCertificateRepository
{
    protected readonly IMapper _mapper;
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public SqlServerUserCertificateRepository(
        IDbConnection connection,
        IDbTransaction transaction,
        IMapper mapper
    )
    {
        _connection = connection;
        _transaction = transaction;
        _mapper = mapper;
    }

    public async void UpdateEmployeeCertificate(string userId, string certificateId)
    {
        await _connection.ExecuteAsync(
            "sp_UpdateEmployeeCertificate",
            new { name = "abc", idtcs = 123 },
            transaction: _transaction,
            commandType: CommandType.StoredProcedure
        );
    }
}

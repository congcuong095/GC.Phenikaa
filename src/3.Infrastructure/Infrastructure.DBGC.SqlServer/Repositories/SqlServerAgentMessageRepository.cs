using System.Data;
using Application.GCRepositories;
using AutoMapper;
using Dapper;

namespace Infrastructure.DBGC.SqlServer.Repositories;

public class SqlServerAgentMessageRepository : IAgentMessageRepository
{
    protected readonly IMapper _mapper;
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public SqlServerAgentMessageRepository(
        IDbConnection connection,
        IDbTransaction transaction,
        IMapper mapper
    )
    {
        _connection = connection;
        _transaction = transaction;
        _mapper = mapper;
    }

    public async Task UpdateAgentMessage(string id, bool isSent)
    {
        await _connection.ExecuteAsync(
            "sp_UpdateAgentMessag",
            new { id, isSent },
            transaction: _transaction,
            commandType: CommandType.StoredProcedure
        );
    }
}

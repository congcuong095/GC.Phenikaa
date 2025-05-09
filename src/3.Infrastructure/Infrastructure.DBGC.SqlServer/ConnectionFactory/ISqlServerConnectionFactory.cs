using System.Data;

namespace Infrastructure.DBGC.SqlServer.ConnectionFactory;

public interface ISqlServerConnectionFactory
{
    IDbConnection CreateConnection();
}

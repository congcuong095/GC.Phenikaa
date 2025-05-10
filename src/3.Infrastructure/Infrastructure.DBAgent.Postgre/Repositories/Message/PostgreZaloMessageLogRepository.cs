using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.DBAgent.Postgre.Context;
using Infrastructure.DBAgent.Postgre.Tables;

namespace Infrastructure.DBAgent.Postgre.Repositories;

public class PostgreZaloMessageLogRepository
    : PostgreAbstractRepository<ZaloMessageLog, ZaloMessageLogPostgre>,
        IZaloMessageLogRepository
{
    public PostgreZaloMessageLogRepository(PostgreDBContext context, IMapper mapper)
        : base(context, mapper) { }
}

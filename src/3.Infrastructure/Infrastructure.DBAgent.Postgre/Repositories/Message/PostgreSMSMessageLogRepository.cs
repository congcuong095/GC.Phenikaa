using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.DBAgent.Postgre.Context;
using Infrastructure.DBAgent.Postgre.Tables;

namespace Infrastructure.DBAgent.Postgre.Repositories;

public class PostgreSMSMessageLogRepository
    : PostgreAbstractRepository<SMSMessageLog, SMSMessageLogPostgre>,
        ISMSMessageLogRepository
{
    public PostgreSMSMessageLogRepository(PostgreDBContext context, IMapper mapper)
        : base(context, mapper) { }
}

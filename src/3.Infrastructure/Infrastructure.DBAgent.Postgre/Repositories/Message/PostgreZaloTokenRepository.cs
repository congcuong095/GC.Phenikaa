using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.DBAgent.Postgre.Context;
using Infrastructure.DBAgent.Postgre.Tables;

namespace Infrastructure.DBAgent.Postgre.Repositories;

public class PostgreZaloTokenRepository
    : PostgreAbstractRepository<ZaloToken, ZaloTokenPostgre>,
        IZaloTokenRepository
{
    public PostgreZaloTokenRepository(PostgreDBContext context, IMapper mapper)
        : base(context, mapper) { }
}

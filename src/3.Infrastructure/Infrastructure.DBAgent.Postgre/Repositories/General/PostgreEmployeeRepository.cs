using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.DBAgent.Postgre.Context;
using Infrastructure.DBAgent.Postgre.Tables;

namespace Infrastructure.DBAgent.Postgre.Repositories;

public class PostgreEmployeeRepository
    : PostgreAbstractRepository<Employee, EmployeePostgre>,
        IEmployeeRepository
{
    public PostgreEmployeeRepository(PostgreDBContext context, IMapper mapper)
        : base(context, mapper) { }
}

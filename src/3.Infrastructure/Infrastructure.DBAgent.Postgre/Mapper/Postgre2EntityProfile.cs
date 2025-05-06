using AutoMapper;
using Domain.Entities;
using Infrastructure.DBAgent.Postgre.Tables;

namespace Infrastructure.DBAgent.Postgre.Mapper;

public class Postgre2EntityProfile : Profile
{
    public Postgre2EntityProfile()
    {
        //map all table to entity
        CreateMap<EmployeePostgre, Employee>();
        CreateMap<Employee, EmployeePostgre>();
    }
}
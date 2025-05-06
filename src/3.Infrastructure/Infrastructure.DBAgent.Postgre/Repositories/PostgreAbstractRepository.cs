using Application.Repositories;
using AutoMapper;
using Domain.Exceptions;
using Infrastructure.DBAgent.Postgre.Context;
using Infrastructure.DBAgent.Postgre.Tables;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBAgent.Postgre.Repositories;

public abstract class PostgreAbstractRepository<T, TTable> : IRepository<T>
    where TTable : BaseTable
{
    protected readonly PostgreDBContext _context;
    protected readonly IMapper _mapper;

    public PostgreAbstractRepository(PostgreDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //Detach entity apart from context after SaveChange to use automapper
    public void DetachEntity(object entity)
    {
        _context.Entry(entity).State = EntityState.Detached;
    }

    public virtual async Task<T> Create(T item)
    {
        var itemMap = _mapper.Map<TTable>(item);

        if (itemMap == null)
            throw new CustomInternalErrorException("InternalErrorER10");

        await _context.AddAsync(itemMap);
        return _mapper.Map<T>(itemMap);
    }

    public virtual async Task<T?> GetOneById(Guid id)
    {
        TTable? item = await _context.Set<TTable>().SingleOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<T>(item);
    }

    public virtual async Task<List<T>?> GetAll()
    {
        List<TTable>? items = await _context.Set<TTable>().ToListAsync();
        return _mapper.Map<List<T>>(items);
    }

    public virtual async Task<List<T>?> GetAllIncludeDeleted()
    {
        List<TTable>? items = await _context.Set<TTable>().IgnoreQueryFilters().ToListAsync();
        return _mapper.Map<List<T>>(items);
    }

    public virtual T Update(T item)
    {
        var itemMap = _mapper.Map<TTable>(item);

        if (itemMap == null)
            throw new CustomInternalErrorException("NOT_FOUND_ENTITY");

        _context.Update(itemMap);
        return _mapper.Map<T>(itemMap);
    }

    public virtual async Task<bool> Delete(Guid id)
    {
        TTable? item = await _context.Set<TTable>().SingleOrDefaultAsync(x => x.Id == id);
        if (item == null)
            throw new CustomNotFoundException("NOT_FOUND_ENTITY");

        _context.Remove(item);
        return true;
    }

    public virtual async Task<bool> SoftDelete(Guid id)
    {
        TTable? item = await _context.Set<TTable>().SingleOrDefaultAsync(x => x.Id == id);
        if (item == null)
            throw new CustomNotFoundException("NOT_FOUND_ENTITY");

        item.DeletedAt = DateTimeOffset.UtcNow;
        _context.Update(item);
        return true;
    }

    public virtual async Task<bool> Restore(Guid id)
    {
        TTable? item = await _context
            .Set<TTable>()
            .IgnoreQueryFilters()
            .SingleOrDefaultAsync(x => x.Id == id);
        if (item == null)
            throw new CustomNotFoundException("NOT_FOUND_ENTITY");
        item.DeletedAt = null;
        _context.Update(item);
        return true;
    }
}

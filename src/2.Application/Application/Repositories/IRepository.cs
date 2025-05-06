namespace Application.Repositories;

public interface IRepository<T>
{
    //Create
    Task<T> Create(T item);

    //Get one by id
    Task<T?> GetOneById(Guid id);

    //Get all
    Task<List<T>?> GetAll();

    //Get all include soft deleted
    Task<List<T>?> GetAllIncludeDeleted();

    //Update one
    T Update(T item);

    //Delete one by id
    Task<bool> Delete(Guid id);

    //Soft Delete one by id
    Task<bool> SoftDelete(Guid id);

    //Restore one by id
    Task<bool> Restore(Guid id);

    //Detach entity from Context
    void DetachEntity(object entity);
}

namespace CorePersistence.Repositories;

public interface IQuery<T>
{
    IQueryable<T> Query();
}


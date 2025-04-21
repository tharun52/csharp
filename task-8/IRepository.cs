using System;

public interface IRepository<T>
{
    void Add(T entity);
    T Get(int id);
    void Update(int id, T entity);
    void Delete(int id);
    void PrintAll();
}

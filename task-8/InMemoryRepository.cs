using System;
using System.Collections.Generic;
using System.Linq;

public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private List<T> _entities = new List<T>();
    private int _nextId = 1;

    public void Add(T entity)
    {
        var entityWithId = entity as dynamic;
        entityWithId.Id = _nextId++;  
        _entities.Add(entity);
        Console.WriteLine("Entity added.");
    }

    public T Get(int id)
    {
        return _entities.FirstOrDefault(e => e.GetHashCode() == id);
    }

    public void Update(int id, T entity)
    {
        var existingEntity = Get(id);
        if (existingEntity != null)
        {
            _entities.Remove(existingEntity);
            _entities.Add(entity);
            Console.WriteLine("Entity updated.");
        }
        else
        {
            Console.WriteLine("Entity not found.");
        }
    }

    public void Delete(int id)
    {
        var entity = Get(id);
        if (entity != null)
        {
            _entities.Remove(entity);
            Console.WriteLine("Entity deleted.");
        }
        else
        {
            Console.WriteLine("Entity not found.");
        }
    }

    public void PrintAll()
    {
        if (_entities.Count == 0)
        {
            Console.WriteLine("No entities to display.");
            return;
        }

        Console.WriteLine("\nEntities List:");
        foreach (var entity in _entities)
        {
            var entityWithId = entity as dynamic;
            Console.WriteLine($"ID: {entityWithId.Id}, Name: {entityWithId.Name}, Price: {entityWithId.Price}");
        }
    }
}

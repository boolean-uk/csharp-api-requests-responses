namespace exercise.wwwapi.Interfaces;

public interface IRepository<T, TKey> where T : class
{
    T Get(TKey value);
    List<T> GetAll(); 
    T Create(T entity);
    T Update(TKey value, T entity);
    T Delete(T entity);
}
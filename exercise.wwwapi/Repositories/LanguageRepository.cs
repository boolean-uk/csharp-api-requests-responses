namespace exercise.wwwapi.Repository;

using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

public interface IRepository<T, U>
{
    public T Create(U entity);
    public IEnumerable<T> GetAll();
    public T Get(Predicate<T> pred);
    public T Update(Predicate<T> pred, U updated);
    public T Delete(Predicate<T> pred);
}

public class LanguageRepository : IRepository<Language, Language>
{
    public Language Create(Language language)
    {
        return LanguageCollection.Add(language);
    }

    public Language Delete(Predicate<Language> pred)
    {
        var found = LanguageCollection.GetAll().Find(pred);
        LanguageCollection.GetAll().Remove(found);
        return found;
    }

    public Language Get(Predicate<Language> pred)
    {
        return LanguageCollection.GetAll().Find(pred);
    }

    public IEnumerable<Language> GetAll()
    {
        return LanguageCollection.GetAll();
    }

    public Language Update(Predicate<Language> pred, Language updated)
    {
        var found = LanguageCollection.GetAll().Find(pred);
        found.name = updated.name;
        return found;
    }
}

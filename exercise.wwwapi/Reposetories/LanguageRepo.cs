using exercise.wwwapi.Data;
using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Reposetories;

public class LanguageRepo : IRepository<Language, string>
{
    public Language Get(string name)
    {
        return LanguageCollection.GetAll().FirstOrDefault(l => l.Name.Equals(name));
    }

    public List<Language> GetAll()
    {
        return LanguageCollection.GetAll();
    }

    public Language Create(Language language)
    {
        return LanguageCollection.Add(language);
    }

    public Language Update(string name, Language language)
    {
        var l = Get(name);
        l.Name = language.Name;
        return l;
    }

    public Language Delete(Language l)
    {
        return LanguageCollection.Remove(l);
    }
}
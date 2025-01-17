using System;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public class LanguageRepository : ILanguageRepository
{
    public Language AddLanguage(string name)
    {
        return LanguageCollection.AddLanguage(name);
    }

    public Language DeleteLanguage(string name)
    {
        return LanguageCollection.DeleteLanguage(name);
    }

    public Language GetLanguage(string name)
    {
        return LanguageCollection.GetLanguage(name);
    }

    public IEnumerable<Language> GetLanguages()
    {
        return LanguageCollection.GetLanguages();
    }

    public Language UpdateLanguage(string currentName, string newName)
    {
        return LanguageCollection.UpdateLanguage(currentName, newName);
    }
}

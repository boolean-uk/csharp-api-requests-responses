using System;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public class LanguageRepository : ILanguageRepository
{
    public LanguageRepository()
    {
    }

    public Language AddLanguage(Language language)
    {
        return LanguageCollection.Add(language);
    }

    public bool DeleteLanguage(string name)
    {
        return LanguageCollection.DeleteLanguage(name);
    }

    public Language GetLanguage(string name)
    {
        return LanguageCollection.GetLanguage(name);
    }

    public IEnumerable<Language> GetLanguages()
    {
        return LanguageCollection.GetAll();
    }

    public Language UpdateLanguage(string name, Language language)
    {
        return LanguageCollection.UpdateLanguage(name, language);
    }
}

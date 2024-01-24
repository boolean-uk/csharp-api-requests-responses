using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public class LanguageRepository : ILanguageRepository
{
    private ILanguageData _languageDatabase;

    public LanguageRepository(ILanguageData languageDatabase)
    {
        _languageDatabase = languageDatabase;
    }
    public Language AddLanguage(Language language)
    {
        return _languageDatabase.AddLanguage(language);
    }

    public IEnumerable<Language> GetLanguages()
    {
        return _languageDatabase.GetLanguages();
    }

    public Language DeleteLanguage(string name)
    {
        return _languageDatabase.DeleteLanguage(name);
    }
}

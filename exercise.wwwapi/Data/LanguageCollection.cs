using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data;


public class LanguageCollection : ILanguageData
{
    private List<Language> _languages = new List<Language>(){
        new Language("Java"),
        new Language("C#")
    };

    public Language AddLanguage(Language language)
    {
        _languages.Add(language);
        return language;
    }

    public List<Language> GetLanguages()
    {
        return _languages;
    }

    public Language DeleteLanguage(string name)
    {
        var toDelete = _languages.FirstOrDefault(x => x.Name == name);
        if (toDelete != null)
        {
            _languages.Remove(toDelete);
        }
        return toDelete;
    }
}

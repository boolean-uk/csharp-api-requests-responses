using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data;

public interface ILanguageData
{
    Language AddLanguage(Language language);
    List<Language> GetLanguages();
    Language DeleteLanguage(string name);
}

using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public interface ILanguageRepository
{
    Language AddLanguage(Language language);
    IEnumerable<Language> GetLanguages();
    Language DeleteLanguage(string name);
}

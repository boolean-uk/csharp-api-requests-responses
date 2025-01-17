using exercise.wwwapi.Core.Models;

namespace exercise.wwwapi.Core.Repositories
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> GetLanguages();
        Language GetSingleLanguage(string name);
        Language AddLanguage(Language language);
        bool UpdateLanguage(string name, Language updatedLanguage);
        bool DeleteLanguage(string name);
    }
}

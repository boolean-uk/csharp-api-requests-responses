using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> GetLanguages();

        Language GetLanguage(string name);
        Language AddLanguage(Language language);
        Language UpdateLanguage(string name, Language language);
        bool DeleteLanguage(string name);
    }
}

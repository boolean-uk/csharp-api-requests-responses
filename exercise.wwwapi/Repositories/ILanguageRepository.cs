using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguage(string name);
        bool Delete(string name);
        Language AddLanguage(Language language);
    }
}

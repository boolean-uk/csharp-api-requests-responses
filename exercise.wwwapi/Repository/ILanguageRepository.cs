using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> GetLanguages();
        void AddLanguage(Language language);
        void DeleteLanguage(Language language);
    }
}

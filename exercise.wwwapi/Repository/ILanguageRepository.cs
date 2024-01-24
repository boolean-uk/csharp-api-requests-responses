using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        public List<Language> GetAllLanguages();

        public Language AddLanguage(string name);

        public Language? UpdateLanguage(string name, LanguageUpdatePayload languageUpdatePayload);

        public Language? DeleteLanguage(string name);

        public Language? GetLanguage(string name);
    }
}
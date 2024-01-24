using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        public List<Language> GetAllLanguages();
        public Language AddLanguage(LanguagePostPayload language);

        public Language? GetLanguage(string language);
        public Language ChangeLanguage(string language, LanguagePostPayload languageData);

        public Language DeleteLanguage(string language);
    }
}

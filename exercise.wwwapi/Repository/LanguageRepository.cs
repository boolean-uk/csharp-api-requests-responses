using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection _languages;
        public LanguageRepository(LanguageCollection languages)
        {
            _languages = languages;
        }
        public Language AddLanguage(LanguagePostPayload language)
        {
            return _languages.Add(language);
        }

        public Language ChangeLanguage(string language, LanguagePostPayload languageData)
        {
            return _languages.Change(language, languageData);
        }

        public Language DeleteLanguage(string language)
        {
            return _languages.Delete(language);
        }

        public List<Language> GetAllLanguages()
        {
            return _languages.GetAll();
        }

        public Language? GetLanguage(string language)
        {
            return _languages.Get(language);
        }
    }
}

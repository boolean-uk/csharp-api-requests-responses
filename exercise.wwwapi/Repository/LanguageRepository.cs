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

        public List<Language> GetLanguages()
        {
            return _languages.GetAll();
        }

        public Language AddLanguage(LanguageCreatePayload languageData)
        {
            return _languages.AddLanguage(languageData);
        }
        public Language GetLanguage(string name)
        {
            return _languages.GetLanguage(name);
        }

        public Language UpdateLanguage(string name, LanguageUpdatePayload updateData)
        {
            return _languages.UpdateLanguage(name, updateData);
        }

        public Language DeleteLanguage(string name)
        {
            return _languages.DeleteLanguage(name);
        }
    }
}

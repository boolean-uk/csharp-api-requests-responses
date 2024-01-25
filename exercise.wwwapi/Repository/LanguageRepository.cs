using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private ILanguageData _languageData;

        public LanguageRepository(ILanguageData languageData)
        {
            _languageData = languageData;
        }

        public List<Language> GetLanguages()
        {
            return _languageData.GetLanguages();
        }

        public Language GetLanguage(string name)
        {
            Language language = _languageData.GetLanguage(name);

            return language;
        }

        public Language AddLanguage(Language language)
        {
            return _languageData.AddLanguage(language);
        }

        public Language UpdateLanguage(string name, LanguagePut language)
        {
            var foundLanguage = _languageData.GetLanguage(name);
            if (foundLanguage == null)
            {
                return null;
            }
            foundLanguage.Name = language.Name;
            return foundLanguage;
        }

        public Language DeleteLanguage(string name)
        {
            return _languageData.DeleteLanguage(name);
        }
    }
}

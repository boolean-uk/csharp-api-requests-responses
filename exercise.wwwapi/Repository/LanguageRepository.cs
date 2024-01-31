using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IlanguageRepository
    {
        private LanguageCollection _languages;

        public LanguageRepository(LanguageCollection languages)
        {
            _languages = languages;
        }
        public List<Language> GetLanguages()
        {
            return _languages.GetList();
        }

        public Language GetLanguageByName(string name) 
        {
            return _languages.GetLanguageByName(name);
        }

        public Language AddLanguage(string name)
        {
            return _languages.AddLanguage(name);
        }

        public Language? UpdateLanguage(string languageName, LanguageItemUpdate updateData)
        {
            var language = _languages.GetLanguageByName(languageName);
            if (language != null) 
            {
                language.name = (string)updateData.languageName;
            }
            return language;


        }

        public Language DeleteLanguage(string languageName) 
        {
            return _languages.DeleteLanguage(languageName);
        }
    }
}

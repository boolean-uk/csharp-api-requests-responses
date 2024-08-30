using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        public Language AddLanguage(Language language)
        {
            LanguageCollection.AddLanguage(language);
            return language;
        }

        public List<Language> GetAllLanguages()
        {
            return LanguageCollection.GetLanguages();
        }

        public Language GetLanguage(string name)
        {
            return LanguageCollection.GetLanguage(name);
        }

        public Language UpdateLanguage(string name, Language language)
        {
            return LanguageCollection.UpdateLanguage(name, language);
        }

        public Language DeleteLanguage(string name)
        {
            return LanguageCollection.DeleteLanguage(name);
        }

        

        

        
    }
}

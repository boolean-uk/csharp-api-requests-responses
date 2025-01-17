using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguage
    {
        public Language AddLanguage(Language language)
        {
            return LanguageCollection.AddLanguage(language);
        }

        public Language DeleteLanguage(string name)
        {
            return LanguageCollection.RemoveLanguage(name);
        }

        public Language GetLanguage(string name)
        {
            return LanguageCollection.GetLanguage(name);
        }

        public List<Language> GetLanguages()
        {
            return LanguageCollection.GetLanguages();
        }

        public Language UpdateLanguage(Language language, string firstName)
        {
            return LanguageCollection.UpdateLanguage(language, firstName);
        }
    }
}

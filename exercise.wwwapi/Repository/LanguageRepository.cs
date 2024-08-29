using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        public Language CreateALanguage(Language language)
        {
            return LanguageCollection.CreateALanguage(language);
        }

        public Language DeleteLanguage(string name)
        {
            return LanguageCollection.DeleteLanguage(name);
        }

        public Language GetALanguage(string name)
        {
            return LanguageCollection.GetALanguage(name);
        }

        public List<Language> GetAllLanguages()
        {
            return LanguageCollection.GetAllLanguages();
        }

        public Language UpdateLanguage(string name, string newName)
        {
            return LanguageCollection.UpdateLanguage(name, newName);
        }
    }
}

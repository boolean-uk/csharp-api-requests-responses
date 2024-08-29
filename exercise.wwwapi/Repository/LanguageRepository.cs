using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        public Language AddLanguage(string name)
        {
            return LanguageCollection.Add(name);
        }

        public Language DeleteLanguage(string name)
        {
            return LanguageCollection.Delete(name);
            
        }

        public Language GetLanguage(string name)
        {
            return LanguageCollection.GetLanguage(name);
        }

        public List<Language> GetLanguages()
        {
            return LanguageCollection.GetAll();
        }

        public Language UpdateLanguage(Language Language)
        {
            return LanguageCollection.UpdateLanguage(Language);
        }
    }
}

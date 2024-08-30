using exercise.wwwapi.Data;
using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language>
    {
        public Language Create(Language language)
        {
            return LanguageCollection.Create(language);
        }

        public Language Delete(string name)
        {
            return LanguageCollection.DeleteLanguage(name);
        }

        public List<Language> GetAll()
        {
            return LanguageCollection.GetAll();
        }

        public Language Get(string name)
        {
            return LanguageCollection.GetSingleLanguage(name);
        }

        public Language Update(string name, Language language)
        {
            return LanguageCollection.UpdateLanguage(name, language);
        }
    }
}

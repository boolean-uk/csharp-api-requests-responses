using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language>
    {
        public Language Add(Language language)
        {
            return LanguageCollection.Add(language);
        }

        public IEnumerable<Language> GetAll()
        {
            return LanguageCollection.GetAll();
        }

        public Language GetOne(string name)
        {
            return LanguageCollection.GetOne(name);
        }

        public Language Update(Language language, string name)
        {
            return LanguageCollection.Update(name, language);
        }
        public Language Delete(string name)
        {
            return LanguageCollection.Remove(name);
        }
    }
}

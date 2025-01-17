using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language>
    {
        public IEnumerable<Language> GetAll()
        {
            return LanguageCollection.GetAll();
        }
        public Language Add(Language language)
        {
            return LanguageCollection.Add(language);
        }
        public Language GetOne(string name)
        {
            return LanguageCollection.GetOne(name);
        }
        public bool Delete(string name)
        {
            return LanguageCollection.Delete(name);
        }
    }
}

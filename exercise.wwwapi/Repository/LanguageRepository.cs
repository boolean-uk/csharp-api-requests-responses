using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language>
    {   
        public List<Language> GetAll()
        {
            return LanguageCollection.getAll();
        }

        public Language GetOne(string name)
        {
            return LanguageCollection.getOne(name);
        }

        public Language Add(Language language)
        {
            return LanguageCollection.Add(language);
        }

        public Language Update(string name, Language language)
        {
            return LanguageCollection.Update(name, language);
        }

        public Language Delete(string name)
        {
            return LanguageCollection.Delete(name);
        }
        
    }
}

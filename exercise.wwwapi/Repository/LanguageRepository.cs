using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language>
    {
        public Language Add(Language entity)
        {
            return LanguageCollection.Add(entity);
        }

        public Language Delete(string name)
        {
            return LanguageCollection.DeleteLanguage(name);
        }

        public Language Get(string name)
        {
            return LanguageCollection.GetALanguage(name);
        }

        public List<Language> GetAll()
        {
            return LanguageCollection.GetAll();
        }

        public Language Update(string name, Language entity)
        {
            return LanguageCollection.UpdateLanguage(name, entity);
        }
    }
}

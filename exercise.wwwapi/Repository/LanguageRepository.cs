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
        public Language Get(string name)
        {
            return LanguageCollection.Get(name);
        }

        public List<Language> GetAll()
        {
            return LanguageCollection.GetAll();
        }

        public Language Update(Language entity, string name)
        {
            return LanguageCollection.Update(entity, name);
        }
        public Language Delete(string name)
        {
            return LanguageCollection.Delete(name);
        }
    }
}

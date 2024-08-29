using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language>
    {
        public Language Create(Language entity)
        {
            return LanguageCollection.Add(entity);
        }

        public Language Delete(string identifier)
        {
            return LanguageCollection.Remove(identifier);
        }

        public Language Get(string identifier)
        {
            return LanguageCollection.Get(identifier);
        }

        public List<Language> GetAll()
        {
            return LanguageCollection.GetAll();
        }

        public Language Update(Language entity, string identifier)
        {
            return LanguageCollection.Update(entity, identifier);
        }
    }
}

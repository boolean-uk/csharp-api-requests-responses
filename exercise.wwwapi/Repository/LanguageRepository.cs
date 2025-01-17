using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language>
    {
        public Language AddEntity(Language entity)
        {
            LanguageCollection.Add(entity);

            return entity;
        }


        public IEnumerable<Language> GetAll()
        {
            return LanguageCollection.getAll();
        }

        public Language GetEntity(string name)
        {
            return LanguageCollection.Get(name);
        }


        public Language RemoveEntity(string name)
        {
            return LanguageCollection.Remove(name);
        }

    }
  
}

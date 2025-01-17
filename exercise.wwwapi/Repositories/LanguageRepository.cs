using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class LanguageRepository : IRepository<Language>
    {
        public void Add(Language entity)
        {
            LanguageCollection.Add(entity);
        }

        public bool Delete(int id)
        {
            return LanguageCollection.Remove(id);
        }

        public IEnumerable<Language> GetAll()
        {
            return LanguageCollection.getAll();
        }

        public Language GetById(int id)
        {
            return LanguageCollection.GetById(id);
        }

        public void Update(Language entity)
        {
            LanguageCollection.Update(entity);
        }
    }
}

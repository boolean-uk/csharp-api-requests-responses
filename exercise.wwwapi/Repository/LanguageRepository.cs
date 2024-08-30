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

        public Language ChangeAnEntity(Language entity, string search)
        {
            var result = LanguageCollection.Change(search, entity);
            return result;
        }

        public string DeleteAnEntity(string search)
        {
            return LanguageCollection.Delete(search);
        }

        public Language GetAEntity(string firstName)
        {
            return LanguageCollection.GetA(firstName);
        }

        public List<Language> GetEntities()
        {
            return LanguageCollection.getAll();
        }
    }
}

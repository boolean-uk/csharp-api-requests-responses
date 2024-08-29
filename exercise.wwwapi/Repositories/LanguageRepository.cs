using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using System.Xml.Linq;

namespace exercise.wwwapi.Repositories
{
    public class LanguageRepository : IRepository<Language>
    {
        public Language Add(Language entity)
        {
            return LanguageCollection.Add(entity);
        }

        public Language Delete(string name)
        {
            return LanguageCollection.Delete(name);
        }

        public Language Get(string name)
        {
            return LanguageCollection.Get(name);
        }

        public List<Language> GetAll()
        {
            return LanguageCollection.GetAll();
        }

        public Language Update(string name, Language entity)
        {
            return LanguageCollection.Update(name, entity);
        }
    }
}

using System.Xml.Linq;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        public Language Add(Language entity)
        {
            return LanguageCollection.Add(entity);
        }

        public bool Delete(string name)
        {
            return LanguageCollection.Remove(name);
        }

        public Language Get(string name)
        {
            return LanguageCollection.Get(name);
        }

        public IEnumerable<Language> GetAll()
        {
            return LanguageCollection.Languages;
        }

        public Language Update(string name, Language entity)
        {
            return LanguageCollection.Update(name, entity);
        }
    }
}

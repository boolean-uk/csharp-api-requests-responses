using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language, string>
    {
        public Language Add(Language entity)
        {
            return LanguageCollection.Add(entity);
        }

        public Language Delete(string languagename)
        {
            return LanguageCollection.Delete(languagename);
        }

        public Language Get(string languagename)
        {
            return LanguageCollection.Get(languagename);
        }

        public List<Language> GetAll()
        {
            return LanguageCollection.GetLanguages();
        }

        public Language Update(string languagename, Language updated)
        {
            return LanguageCollection.Update(languagename, updated);
        }
    }
}

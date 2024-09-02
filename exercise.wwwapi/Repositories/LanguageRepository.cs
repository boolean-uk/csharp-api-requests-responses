
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class LanguageRepository
    {
        public Language Delete(string name)
        {
            return LanguageCollection.Delete(name);
        }

        public Language GetA(string name)
        {
            return LanguageCollection.GetA(name);
        }

        public List<Language> GetAll()
        {
            return LanguageCollection.GetAll();
        }

        public Language Update(string name)
        {
            return LanguageCollection.Update(name);
        }
        public Language Create(Language language)
        {
            return LanguageCollection.Create(language);
        }
    }
}

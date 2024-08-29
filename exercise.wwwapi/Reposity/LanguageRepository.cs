using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Reposity
{
    public class LanguageRepository : IRepository<Language>
    {
        public Language Add(Language language)
        {
            LanguageCollection.Add(language);
            return language;
        }

        public Language Delete(string Name)
        {
            Language language = LanguageCollection.Delete(Name);
            return language;
        }

        public Language Get(string Name)
        {
            return LanguageCollection.Get(Name);
        }

        public List<Language> getAll()
        {
            return LanguageCollection.getAll();
        }

        public Language Update(string Name, Language language)
        {
            return LanguageCollection.Update(Name, language);
        }
    }
}

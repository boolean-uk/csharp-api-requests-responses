using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language>
    {
        public IData<Language> _languageDatabase;

        public LanguageRepository(IData<Language> languageDatabase)
        {
            _languageDatabase = languageDatabase;
        }

        public Language Get(string name)
        {
            return _languageDatabase.Get(name);
        }
        public IEnumerable<Language> GetAll()
        {
            return _languageDatabase.GetAll();
        }

        public Language Add(Language language)
        {
            return _languageDatabase.Add(language);
        }

        public Language Update(string name, Language language)
        {
           return _languageDatabase.Update(name, language);
        }

        public Language Delete(string name)
        {
            return _languageDatabase.Delete(name);
        }
    }
}

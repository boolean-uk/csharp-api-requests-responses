using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection _languageCollection;

        public LanguageRepository(LanguageCollection languageCollection)
        {
            _languageCollection = languageCollection;
        }

        public Language Create(Language language)
        {
            return _languageCollection.Add(language);
        }

        public Language Delete(string name)
        {
            return _languageCollection.Remove(name);
        }

        public Language Get(string name)
        {
            return _languageCollection.Get(name);
        }

        public IEnumerable<Language> Get()
        {
            return _languageCollection.Get();
        }

        public Language Update(string name, Language language)
        {
            return _languageCollection.Update(name, language);
        }
    }
}

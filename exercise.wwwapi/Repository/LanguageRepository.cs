using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection _languageCollection;

        public LanguageRepository(LanguageCollection languages)
        {
            _languageCollection = languages;
        }

        public Language Create(Language language)
        {

            return _languageCollection.Add(language);
        }

        public List<Language> GetAll()
        {
            return _languageCollection.GetAll();
        }

        public Language Get(string firstName)
        {

            return _languageCollection.Get(firstName);
        }

        public Language Update(string name, Language language)
        {
            return _languageCollection.Update(name, language);
        }

        public Language Delete(string name)
        {
            return _languageCollection.Delete(name);
        }

    }
}

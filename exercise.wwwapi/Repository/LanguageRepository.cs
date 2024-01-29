using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{


    public class LanguageRepository : IRepository<Language>
    {
        private readonly LanguageCollection _languageCollection;

        public LanguageRepository(LanguageCollection languageCollection)
        {
            _languageCollection = languageCollection;
        }

        public List<Language> GetAll()
        {
            return _languageCollection.getAll();
        }

        public Language Add(Language lang)
        {
            return _languageCollection.Add(lang);
        }

        public bool Delete(Language lang)
        {
            return _languageCollection.Delete(lang);
        }
    }
}
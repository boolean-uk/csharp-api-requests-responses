using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface ILanguageRepository
    {
        List<Language> GetAll();
        Language Add(Language lang);
        bool Delete(Language lang);
    }


    public class LanguageRepository : ILanguageRepository
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
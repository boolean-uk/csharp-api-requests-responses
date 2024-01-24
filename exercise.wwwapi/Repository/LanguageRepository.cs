using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection _languageDatabase;

        public LanguageRepository(LanguageCollection languageDatabase)
        {
            _languageDatabase = languageDatabase;
        }
        public IEnumerable<Language> GetLanguages()
        {
            return _languageDatabase.GetAll();
        }

        public void AddLanguage(Language language)
        {
            _languageDatabase.Add(language);
        }

        public void DeleteLanguage(Language language)
        {
            _languageDatabase.Delete(language);
        }
    }
}

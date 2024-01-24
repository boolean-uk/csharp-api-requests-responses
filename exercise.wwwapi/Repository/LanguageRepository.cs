using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {

        private LanguageCollection _languages;
        public LanguageRepository(LanguageCollection language) { 
            _languages = language;
        }
        public Language AddLanguage(LanguagePostPayload payload)
        {
            return _languages.AddLanguage(payload);
        }

        public void deleteLanguage(string name)
        {
            throw new NotImplementedException();
        }

        public List<Language> getAllLanguages()
        {
            return _languages.getAllLanguages();
        }

        public Language GetLanguageByName(string name)
        {
            throw new NotImplementedException();
        }

        public Language UpdateLanguage(string name, LanguagePutPayload payload)
        {
            throw new NotImplementedException();
        }
    }
}

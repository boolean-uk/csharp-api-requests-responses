using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection _languageCollection;

        public LanguageRepository(LanguageCollection languagecollection) 
        {
          _languageCollection = languagecollection;
        
        }
        public IEnumerable<Language> GetLangs()
        {
            return _languageCollection.GetLangs();
        }

        public Language AddLang(Language language)
        {
            return _languageCollection.AddLang(language);
        }
        public Language GetLang(string name)
        {
            return _languageCollection.GetLang(name);
        }

        public Language UpdateLang(string name, Language language) 
        {
        return _languageCollection.UpdateLang(name, language);
  
        }

        public Language DeleteLang(string name)
        {
            return _languageCollection.DeleteLang(name);
        }
    }
}

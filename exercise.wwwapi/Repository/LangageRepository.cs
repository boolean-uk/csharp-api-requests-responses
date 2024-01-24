using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LangageRepository : ILangageRepository
    {
        private LanguageCollection _langauages;
        public LangageRepository(LanguageCollection languages) 
        {
            this._langauages = languages;
        }
        public Language CreateLanguage(Language language) 
        {
           return this._langauages.CreateLanguage(language);
        }

        public List<Language> GetLanguages() 
        {
            return this._langauages.GetLanguages();
        }

        public Language GetLanguage(string name) 
        {
            return this._langauages.GetLanguage(name);
        }

        public Language Update(string name, Language language) 
        {
            return this._langauages.Update(name, language);
        }

        public Language Delete(string name) 
        {
            return this._langauages.Delete(name);
        }
    }
}

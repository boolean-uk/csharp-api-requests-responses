using exercise.wwwapi.Models;
using exercise.wwwapi.Data;

namespace exercise.wwwapi.Repository
{
    public class LanguagueRepository : ILanguageRepository
    {
        
        private LanguageCollection _languages;

        public LanguagueRepository(LanguageCollection languages)
        {
            _languages = languages;
        }
        public Language Add(Language language)
        {
            return _languages.Add(language);
        }

        public Language deleteLanguage(string language)
        {
            return _languages.deleteLanguage(language);
        }

        public Language getALanguage(string langaugename)
        {
            return _languages.getALanguage(langaugename);
        }

        public List<Language> getAll()
        {
            return _languages.getAll();
        }

        public Language updateLanguage(string langaugename, string newName)
        {
            return _languages.updateLanguage(langaugename, newName);
        }
    }
}
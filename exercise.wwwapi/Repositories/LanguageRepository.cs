using exercise.wwwapi.Data;
using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        public Language AddLanguage(Language language)
        {
            return LanguageCollection.Add(language);
        }

        public void DeleteLanguage(string name)
        {
            LanguageCollection.Delete(name);
        }

        public Language GetALanguage(string name)
        {
            return LanguageCollection.GetLanguage(name);
        }

        public List<Language> GetAllLanguages()
        {
            return LanguageCollection.GetLanguages();
        }

        public Language UpdateLanguaget(string name, Language languageValue)
        {
            return LanguageCollection.Update(name, languageValue);
        }
    }
}

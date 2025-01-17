using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        public void AddLanguage(Language language)
        {
            LanguageCollection.AddLanguage(language);
        }

        public IEnumerable<Language> GetAllLanguages()
        {
            return LanguageCollection.GetLanguages();
        }

        public Language GetLanguageByName(string name)
        {
            return LanguageCollection.GetLanguageByName(name);
        }

        public Language UpdateLanguageInfo(string old, string newName)
        {

            return LanguageCollection.UpdateLanguageInfo(old, newName);
        }

        public Language DeleteLanguage(string name)
        {
            return LanguageCollection.DeleteLanguage(name);
        }
    }
}

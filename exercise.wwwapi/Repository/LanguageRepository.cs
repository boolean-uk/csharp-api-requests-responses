using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        public Language GetLanguage(string name)
        {
            return LanguageCollection.Get(name);
        }

        public IEnumerable<Language> GetLanguages()
        {
            return LanguageCollection.Languages;
        }

        public Language AddLanguage(Language language)
        {
            return LanguageCollection.Add(language);

        }

        public bool DeleteLanguage(string name)
        {
            return LanguageCollection.Delete(name);
        }

        public Language UpdateLanguage(string name, Language language)
        {
            return LanguageCollection.Update(name, language);
        }
    }
}

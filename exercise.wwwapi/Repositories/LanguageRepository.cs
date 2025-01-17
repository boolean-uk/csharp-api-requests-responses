using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class LanguageRepository : ILanguage
    {
        public Language CreateLanguage(Language language)
        {
            return LanguageCollection.Add(language);
        }

        public Language DeleteLanguage(string language)
        {
            return LanguageCollection.Delete(language);
        }

        public Language GetLanguage(string language)
        {
            return LanguageCollection.Get(language);
        }

        public IEnumerable<Language> GetLanguages()
        {
            return LanguageCollection.GetAll();
        }

        public Language UpdateLanguage(string languageToUpdate, Language updatedLangauge)
        {
            return LanguageCollection.Update(languageToUpdate, updatedLangauge);
        }
    }
}

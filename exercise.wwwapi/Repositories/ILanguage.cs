using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public interface ILanguage
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguage(string language);
        Language CreateLanguage(Language language);
        Language UpdateLanguage(string languageToUpdate, Language updatedLangauge);
        Language DeleteLanguage(string language);
    }
}

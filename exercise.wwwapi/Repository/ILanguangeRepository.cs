using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        List<Language> GetLanguages();
        Language GetLanguage(string name);
        Language AddLanguage(Language language);
        Language UpdateLanguage(string name, LanguagePut language);
        Language DeleteLanguage(string name);

    }
}

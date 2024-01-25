using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface ILanguageData
    {
        Language GetLanguage(string name);
        List<Language> GetLanguages();
        Language AddLanguage(Language language);

        Language UpdateLanguage(string name, LanguagePut language);
        Language DeleteLanguage(string name);
    }
}

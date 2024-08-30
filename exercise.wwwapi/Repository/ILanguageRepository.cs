using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        List<Language> GetAllLanguages();

        Language AddLanguage(Language language);

        Language GetLanguage(string name);

        Language UpdateLanguage(string name, Language language);

        Language DeleteLanguage(string name);
    }
}

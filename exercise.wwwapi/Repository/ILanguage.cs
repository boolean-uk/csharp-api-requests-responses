using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguage
    {
        List<Language> GetLanguages();

        Language GetLanguage(string firstName);

        Language AddLanguage(Language language);
        Language UpdateLanguage(Language language, string firstName);
        Language DeleteLanguage(string firstName);
    }
}

using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        Language AddLanguage(Language Language);

        List<Language> GetLanguages();

        Language GetLanguage(int id);

        Language UpdateLanguage(Language Language);

        Language DeleteLanguage(int id);
    }
}

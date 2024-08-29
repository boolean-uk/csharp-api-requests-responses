using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        List<LanguageRepository> GetAllLanguages();

        Language AddLanguage(Language language);

        Language GetLanguage(string name);

        Language UpdateLanguage(string name, string newname);

        Language DeleteLanguage(string name);
    }
}

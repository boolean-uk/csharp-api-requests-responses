using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        Language CreateALanguage(Language language);
        List<Language> GetAllLanguages();
        Language GetALanguage(string name);
        Language UpdateLanguage(string name, string newName);
        Language DeleteLanguage(string name);

    }
}

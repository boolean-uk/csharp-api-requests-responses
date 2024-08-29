using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        List<Language> GetAll();

        Language GetALanguage(string name);

        Language CreateLanguage(string name);

        Language UpdateLanguage(string name, string newName);

        Language DeleteLanguage(string name);
    }
}

using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {

        IEnumerable<Language> GetLangs();
        Language AddLang(Language language);
        Language GetLang(string name);

        Language UpdateLang(string name, Language language);

        Language DeleteLang(string name);

    }
}

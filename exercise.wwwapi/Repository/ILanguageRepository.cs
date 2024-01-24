using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> Get();
        Language Get(string name);
        Language Create(Language language);
        Language Update(string name, Language language);
        Language Delete(string name);
    }
}

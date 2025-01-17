using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        Language Add(Language entity);
        IEnumerable<Language> GetAll();
        Language Get(string name);
        Language Update(string name, Language entity);
        bool Delete(string name);
    }
}

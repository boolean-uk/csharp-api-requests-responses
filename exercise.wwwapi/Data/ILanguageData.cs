using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface ILanguageData
    {
        List<Language> GetAll();
        Language Add(Language language);
        Language Get(string name);
        Language Update(string name, Language language);
        Language Delete(string name);
    }
}

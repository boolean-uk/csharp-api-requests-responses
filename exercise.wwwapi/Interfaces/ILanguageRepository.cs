using exercise.wwwapi.Models;

namespace exercise.wwwapi.Interfaces
{
    public interface ILanguageRepository
    {
        Language Add(Language language);
        List<Language> GetAll();
        Language Get(string name);
        Language Update(string name , Language updatedLanguage);
        Language Delete(string name);
    }
}
